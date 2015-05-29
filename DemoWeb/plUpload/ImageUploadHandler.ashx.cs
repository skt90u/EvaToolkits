using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// ImageUploadHandler 的摘要描述
/// </summary>
public class ImageUploadHandler : plUploadFileHandler
{
    private string ImageStoragePath;
    private static int ImageHeight = 480;

    public ImageUploadHandler()
    {
        // 檔案實際儲存資料夾
        ImageStoragePath = "~/TempUploads";
        // 檔案上傳資料夾
        FileUploadPhysicalPath = "~/TempUploads";

        MaxUploadSize = 2000000;
    }

    protected override void OnUploadCompleted(string fileName)
    {
        // 上傳檔案路徑
        string uploadedFilePath = Path.Combine(FileUploadPhysicalPath, fileName);

        // TODO: 根據傳遞的 QueryString, 產生對應真正要儲存到伺服器的檔案名稱
        var SEQ = Request.QueryString["SEQ"];

        // 真正要儲存到伺服器的檔案名稱
        string generatedFilename = string.Format("{0}馫{1}馫{2}", SEQ, DateTime.Now.Ticks, fileName); // 序號_時間_檔名

        // 真正要儲存到伺服器的檔案路徑
        string imagePath = Context.Server.MapPath(ImageStoragePath);
        string generatedFilePath = Path.Combine(imagePath, generatedFilename);

        // resize the image and write out in final image folder
        ResizeImage(uploadedFilePath, generatedFilePath, ImageHeight);

        // delete the temp file
        File.Delete(uploadedFilePath);

        string relativePath = VirtualPathUtility.ToAbsolute(ImageStoragePath);
        string finalImageUrl = relativePath + "/" + generatedFilename;

        WriteUploadCompletedMessage(finalImageUrl); // return just a string that contains the url path to the file
    }

    private void ResizeImage(string srcFileName, string dstFileName, int imageHeight)
    {
        File.Copy(srcFileName, dstFileName, true);
    }

    protected override bool OnUploadStarted(int chunk, int chunks, string name)
    {
        if (!Directory.Exists(FileUploadPhysicalPath))
            Directory.CreateDirectory(FileUploadPhysicalPath);

        if (!Directory.Exists(Context.Server.MapPath(ImageStoragePath)))
            Directory.CreateDirectory(Context.Server.MapPath(ImageStoragePath));

        Westwind.Utilities.FileUtils.DeleteTimedoutFiles(Path.Combine(FileUploadPhysicalPath, "*.*"), 900); // time out files after 15 minutes - temporary upload files

        Westwind.Utilities.FileUtils.DeleteTimedoutFiles(Path.Combine(Context.Server.MapPath(ImageStoragePath), "*.*"), 900); // clean out final image folder too

        return base.OnUploadStarted(chunk, chunks, name);
    }

    // these aren't needed in this example and with files in general
    // use these to stream data into some alternate data source
    // when directly inheriting from the base handler

    //protected override bool  OnUploadChunk(Stream chunkStream, int chunk, int chunks, string fileName)
    //{
    //     return base.OnUploadChunk(chunkStream, chunk, chunks, fileName);
    //}

    //protected override bool OnUploadChunkStarted(int chunk, int chunks, string fileName)
    //{
    //    return true;
    //}
}