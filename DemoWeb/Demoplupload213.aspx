﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demoplupload213.aspx.cs" Inherits="DemoWeb.Demoplupload213" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title></title>
    <link href="Scripts/plupload/jquery-ui-themes-1.10.2/themes/smoothness/jquery-ui.min.css" rel="stylesheet" />
    <link href="Scripts/plupload/plupload-2.1.3/js/jquery.ui.plupload/css/jquery.ui.plupload.css" rel="stylesheet" />
    <script src="Scripts/plupload/jquery.min.js"></script>
</head>

<body>
    <div id="uploader" />

    <script type="text/javascript">
        // Initialize the widget when the DOM is ready
        $(function () {
            $("#uploader").plupload({
                // General settings
                runtimes: 'html5,flash,silverlight,html4',
                url: "plUpload/ImageUploadHandler.ashx?SEQ=0123456789",

                // Maximum file size
                max_file_size: '2mb',

                chunk_size: '1mb',

                // Resize images on clientside if we can
                resize: {
                    width: 200,
                    height: 200,
                    quality: 90,
                    crop: true // crop to exact dimensions
                },

                // Specify what files to browse for
                filters: [
                    { title: "Image files", extensions: "jpg,gif,png" },
                    { title: "Zip files", extensions: "zip,avi" }
                ],

                // Rename files by clicking on their titles
                rename: true,

                // Sort files
                sortable: true,

                // Enable ability to drag'n'drop files onto the widget (currently only HTML5 supports that)
                dragdrop: true,

                // Views to activate
                views: {
                    list: true,
                    thumbs: true, // Show thumbs
                    active: 'thumbs'
                },

                // Flash settings
                flash_swf_url: '/plupload/js/Moxie.swf',

                // Silverlight settings
                silverlight_xap_url: '/plupload/js/Moxie.xap',

                // PreInit events, bound before any internal events
                preinit: {
                    Init: function (up, info) {
                        log('[Init]', 'Info:', info, 'Features:', up.features);
                    },

                    UploadFile: function (up, file) {
                        log('[UploadFile]', file);

                        // You can override settings before the file is uploaded
                        // up.setOption('url', 'upload.php?id=' + file.id);
                        // up.setOption('multipart_params', {param1 : 'value1', param2 : 'value2'});
                    }
                },

                // Post init events, bound after the internal events
                init: {
                    PostInit: function () {
                        // Called after initialization is finished and internal event handlers bound
                        log('[PostInit]');

                        //document.getElementById('uploadfiles').onclick = function () {
                        //    uploader.start();
                        //    return false;
                        //};
                    },

                    Browse: function (up) {
                        // Called when file picker is clicked
                        log('[Browse]');
                    },

                    Refresh: function (up) {
                        // Called when the position or dimensions of the picker change
                        log('[Refresh]');
                    },

                    StateChanged: function (up) {
                        // Called when the state of the queue is changed
                        log('[StateChanged]', up.state == plupload.STARTED ? "STARTED" : "STOPPED");
                    },

                    QueueChanged: function (up) {
                        // Called when queue is changed by adding or removing files
                        log('[QueueChanged]');
                    },

                    OptionChanged: function (up, name, value, oldValue) {
                        // Called when one of the configuration options is changed
                        log('[OptionChanged]', 'Option Name: ', name, 'Value: ', value, 'Old Value: ', oldValue);
                    },

                    BeforeUpload: function (up, file) {
                        // Called right before the upload for a given file starts, can be used to cancel it if required
                        log('[BeforeUpload]', 'File: ', file);
                    },

                    UploadProgress: function (up, file) {
                        // Called while file is being uploaded
                        log('[UploadProgress]', 'File:', file, "Total:", up.total);
                    },

                    FileFiltered: function (up, file) {
                        // Called when file successfully files all the filters
                        log('[FileFiltered]', 'File:', file);
                    },

                    FilesAdded: function (up, files) {
                        // Called when files are added to queue
                        log('[FilesAdded]');

                        plupload.each(files, function (file) {
                            log('  File:', file);
                        });
                    },

                    FilesRemoved: function (up, files) {
                        // Called when files are removed from queue
                        log('[FilesRemoved]');

                        plupload.each(files, function (file) {
                            log('  File:', file);
                        });
                    },

                    FileUploaded: function (up, file, info) {
                        // Called when file has finished uploading
                        log('[FileUploaded] File:', file, "Info:", info);
                    },

                    ChunkUploaded: function (up, file, info) {
                        // Called when file chunk has finished uploading
                        log('[ChunkUploaded] File:', file, "Info:", info);
                    },

                    UploadComplete: function (up, files) {
                        // Called when all files are either uploaded or failed
                        log('[UploadComplete]');
                    },

                    Destroy: function (up) {
                        // Called when uploader is destroyed
                        log('[Destroy] ');
                    },

                    Error: function (up, args) {
                        // Called when error occurs
                        log('[Error] ', args);
                    }
                }
            });

            function log() {
                var str = "";

                plupload.each(arguments, function (arg) {
                    var row = "";

                    if (typeof (arg) != "string") {
                        plupload.each(arg, function (value, key) {
                            // Convert items in File objects to human readable form
                            if (arg instanceof plupload.File) {
                                // Convert status to human readable
                                switch (value) {
                                    case plupload.QUEUED:
                                        value = 'QUEUED';
                                        break;

                                    case plupload.UPLOADING:
                                        value = 'UPLOADING';
                                        break;

                                    case plupload.FAILED:
                                        value = 'FAILED';
                                        break;

                                    case plupload.DONE:
                                        value = 'DONE';
                                        break;
                                }
                            }

                            if (typeof (value) != "function") {
                                row += (row ? ', ' : '') + key + '=' + value;
                            }
                        });

                        str += row + " ";
                    } else {
                        str += arg + " ";
                    }
                });

                //var log = $('#log');
                //log.append(str + "\n");
                //log.scrollTop(log[0].scrollHeight);

                if(window.console && window.console.log)
                    window.console.log(str);
            }
        });
    </script>

    <script src="Scripts/plupload/jquery-ui-1.10.2/ui/minified/jquery-ui.min.js"></script>
    <script src="Scripts/plupload/plupload-2.1.3/js/plupload.full.min.js"></script>
    <script src="Scripts/plupload/plupload-2.1.3/js/jquery.ui.plupload/jquery.ui.plupload.min.js"></script>
</body>
</html>
