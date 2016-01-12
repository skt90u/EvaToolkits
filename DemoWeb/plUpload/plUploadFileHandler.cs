using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class plUploadFileHandler : plUploadBaseHandler
{
    private string UnableToWriteOutFile = "無法寫入檔案";
    private string UploadDirectoryDoesnTExistAndCouldnTCreate = "上傳資料夾不存在，無法建立";

    /// <summary>
    /// Physical folder location where the file will be uploaded.
    /// 
    /// Note that you can assign an IIS virtual path (~/path)
    /// to this property, which automatically translates to a 
    /// physical path.
    /// </summary>
    public string FileUploadPhysicalPath
    {
        get
        {
            if (_FileUploadPhysicalPath.StartsWith("~"))
                _FileUploadPhysicalPath = Context.Server.MapPath(_FileUploadPhysicalPath);
            return _FileUploadPhysicalPath;
        }
        set
        {
            _FileUploadPhysicalPath = value;
        }
    }
    private string _FileUploadPhysicalPath;


    public plUploadFileHandler()
    {
        FileUploadPhysicalPath = Path.GetTempPath();
    }

    /// <summary>
    /// Stream each chunk to a file and effectively append it. 
    /// </summary>
    protected override bool OnUploadChunk(Stream chunkStream, int chunk, int chunks, string uploadedFilename)
    {
        var path = FileUploadPhysicalPath;

        // try to create the path
        if (!Directory.Exists(path))
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                string error = string.Format("在建立上傳檔案，{0}, Reason: {1}", UploadDirectoryDoesnTExistAndCouldnTCreate, ex.Message);
                WriteErrorResponse(error);
                return false;
            }
        }

        string uploadFilePath = Path.Combine(path, uploadedFilename);
        if (chunk == 0)
        {
            if (File.Exists(uploadFilePath))
                File.Delete(uploadFilePath);
        }

        Stream stream = null;
        try
        {
            stream = new FileStream(uploadFilePath, (chunk == 0) ? FileMode.CreateNew : FileMode.Append);
            chunkStream.CopyTo(stream, 16384);
        }
        catch (Exception ex)
        {
            string error = string.Format("{0}, Reason: {1}", UnableToWriteOutFile, ex.Message);
            WriteErrorResponse(error);
            return false;
        }
        finally
        {
            if (stream != null)
                stream.Dispose();
        }

        return true;
    }
}