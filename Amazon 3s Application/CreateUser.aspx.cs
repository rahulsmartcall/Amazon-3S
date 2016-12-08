using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using FileStorageUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amazon_3s_Application
{
    public partial class CreateUser : System.Web.UI.Page
    {

        public string PublicKey = ConfigurationManager.AppSettings["AWSAccessKey"];
        public string SecretKey = ConfigurationManager.AppSettings["AWSSecretKey"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getBucketUserList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AmazonS3Config config = new AmazonS3Config();

                config.ServiceURL = "s3.amazonaws.com";

                AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);


                PutBucketRequest request = new PutBucketRequest();
                request.BucketName = txtBucketName.Text;
                s3Client.PutBucket(request);

                lbList.Items.Clear();

                getBucketUserList();

                lblmessage.Text = request.BucketName + ": Created Successfully";
            }
            catch (Exception ex)
            {

            }
        }

        private void getBucketUserList()
        {
            try
            {

                AmazonS3Config config = new AmazonS3Config();

                config.ServiceURL = "s3.amazonaws.com";

                AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

                ListBucketsResponse response = s3Client.ListBuckets();
                foreach (S3Bucket b in response.Buckets)
                {
                    // +" " + b.CreationDate

                    string BID = b.BucketName;

                    lbList.Items.Add(BID);

                }
            }
            catch (Exception ex)
            {

            }

        }



        public void CreateFolder(string bucket, string folder, string subDirectoryInBucket)
        {
            try
            {

                AmazonS3Config config = new AmazonS3Config();

                config.ServiceURL = "s3.amazonaws.com";

                AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

                var key = string.Format(@"{0}/", folder);
                var request = new PutObjectRequest().WithBucketName(bucket).WithKey(key);

                //   request.InputStream = new MemoryStream();

                //  TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

                if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
                {
                    request.BucketName = bucket;
                }
                else
                {
                    request.BucketName = bucket + @"/" + subDirectoryInBucket;
                }

                request.Key = key;

                request.InputStream = new MemoryStream();

                s3Client.PutObject(request);

                lblfolderMessage.Text = request.Key + ": Created Successfully";
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCreateFolder_Click(object sender, EventArgs e)
        {
            string folderName = lbList.SelectedItem.Text + " " + DateTime.Now;

            if (lbBucketFiles.SelectedItem != null)
            {
                CreateFolder(lbList.SelectedItem.Text, txtFolderName.Text, lbBucketFiles.SelectedItem.Text);
            }
            else
            {
                CreateFolder(lbList.SelectedItem.Text, txtFolderName.Text, "");
            }
        }

        //public void InserFilesOnFolder(string bucket, string folderName)
        //{

        //    AmazonS3Config config = new AmazonS3Config();
        //    config.ServiceURL = "s3.amazonaws.com";
        //    AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

        //    FileInfo filename = new FileInfo(@"c:\test apps.zip");
        //    //  string contents = File.ReadAllText(filename.FullName);

        //    try
        //    {
        //        PutObjectRequest putObjectRequest = new PutObjectRequest();
        //        // putObjectRequest.ContentBody = contents;
        //        String delimiter = "/";
        //        putObjectRequest.BucketName = string.Concat(bucket, delimiter, folderName);
        //        putObjectRequest.Key = filename.Name;
        //        PutObjectResponse putObjectResponse = s3Client.PutObject(putObjectRequest);
        //    }
        //    catch (AmazonS3Exception e)
        //    {
        //        Console.WriteLine("File creation within folder has failed.");
        //        Console.WriteLine("Amazon error code: {0}", string.IsNullOrEmpty(e.ErrorCode) ? "None" : e.ErrorCode);
        //        Console.WriteLine("Exception message: {0}", e.Message);
        //    }

        //}

        public void GetFileList(string bucket)
        {
            try
            {

                lbBucketFiles.Items.Clear();

                AmazonS3Config config = new AmazonS3Config();

                config.ServiceURL = "s3.amazonaws.com";

                AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

                // List all objects
                ListObjectsRequest listRequest = new ListObjectsRequest
                {
                    BucketName = bucket,
                };

                ListObjectsResponse listResponse;
                do
                {

                    listResponse = s3Client.ListObjects(listRequest);
                    foreach (S3Object obj in listResponse.S3Objects)
                    {

                        //   string filesList = obj.Key + "" + obj.Size + "" + obj.LastModified + "" + obj.StorageClass;

                        string filesList = obj.Key;

                        lbBucketFiles.Items.Add(filesList);

                        //Console.WriteLine("Object - " + obj.Key);
                        //Console.WriteLine(" Size - " + obj.Size);
                        //Console.WriteLine(" LastModified - " + obj.LastModified);
                        //Console.WriteLine(" Storage class - " + obj.StorageClass);
                    }

                    listRequest.Marker = listResponse.NextMarker;
                }
                while (listResponse.IsTruncated);

            }
            catch (Exception ex)
            {
            


            }
        }

        protected void btnBucketFile_Click(object sender, EventArgs e)
        {

            GetFileList(lbList.SelectedItem.Text);

        }

        protected void btnUploadFiles_Click(object sender, EventArgs e)
        {

            #region

            //    InserFilesOnFolder(lbList.SelectedItem.Text, lbBucketFiles.SelectedItem.Text);

            //try
            //{
            //    // var fileStorageProvider = new AmazonS3FileStorageProvider();

            //    //  btnChooseFile.SaveAs(@"c:\\upload\\" + btnChooseFile.FileName);

            //    //   string filesname = @"c:\\upload\\" + btnChooseFile.FileName;
            //    //   


            //    FileInfo filename = new FileInfo(@"c:\UsemyFile.txt");
            //    string contents = File.ReadAllText(filename.FullName);

            //    FileUpload(PublicKey, SecretKey, lbList.SelectedItem.Text, filename.Name, string.Format("{0}/complete.aspx", Request.Url.AbsoluteUri));

            //    SetPolicy(GetPolicySString(filename.Name, lbList.SelectedItem.Text, "complete.aspx"));

            //}
            //catch (Exception ex)
            //{


            //}
            #endregion

            Stream st = btnChooseFile.PostedFile.InputStream;

            if (lbBucketFiles.SelectedItem != null)
            {

                sendMyFileToS3(st, lbList.SelectedItem.Text, lbBucketFiles.SelectedItem.Text, btnChooseFile.FileName);
            }
            else
            {
                sendMyFileToS3(st, lbList.SelectedItem.Text, "", btnChooseFile.FileName);

            }
        }

        public void RunDownloadFileDemo()
        {

            //try
            //{

            //    AmazonS3Config config = new AmazonS3Config();
            //    config.ServiceURL = "s3.amazonaws.com";
            //    AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

            //    GetObjectRequest getObjectRequest = new GetObjectRequest();
            //    getObjectRequest.BucketName = "a-second-bucket-test";
            //    getObjectRequest.Key = "logfile.txt";
            //    GetObjectResponse getObjectResponse = s3Client.GetObject(getObjectRequest);

            //    MetadataCollection metadataCollection = getObjectResponse.Metadata;

            //    ICollection<string> keys = metadataCollection.Keys;

            //    foreach (string key in keys)
            //    {
            //        Console.WriteLine("Metadata key: {0}, value: {1}", key, metadataCollection[key]);
            //    }

            //    using (Stream stream = getObjectResponse.ResponseStream)
            //    {
            //        long length = stream.Length;
            //        byte[] bytes = new byte[length];
            //        int bytesToRead = (int)length;
            //        int numBytesRead = 0;
            //        do
            //        {
            //            int chunkSize = 1000;
            //            if (chunkSize > bytesToRead)
            //            {
            //                chunkSize = bytesToRead;
            //            }
            //            int n = stream.Read(bytes, numBytesRead, chunkSize);
            //            numBytesRead += n;
            //            bytesToRead -= n;
            //        }
            //        while (bytesToRead > 0);
            //        String contents = Encoding.UTF8.GetString(bytes);
            //        Console.WriteLine(contents);
            //    }
            //}
            //catch (AmazonS3Exception e)
            //{
            //    Console.WriteLine("Object download has failed.");
            //    Console.WriteLine("Amazon error code: {0}",
            //        string.IsNullOrEmpty(e.ErrorCode) ? "None" : e.ErrorCode);
            //    Console.WriteLine("Exception message: {0}", e.Message);
            //}

        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DelFilesToS3(lbList.SelectedItem.Text, lbBucketFiles.SelectedItem.Text);
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadObject(lbList.SelectedItem.Text, lbBucketFiles.SelectedItem.Text);
        }

        public bool sendMyFileToS3(Stream localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
        {

            AmazonS3Config config = new AmazonS3Config();
            config.ServiceURL = "s3.amazonaws.com";
            AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

            TransferUtility utility = new TransferUtility(s3Client);

            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
            {
                request.BucketName = bucketName;
            }
            else
            {
                request.BucketName = bucketName + @"/" + subDirectoryInBucket;
            }

            request.Key = fileNameInS3;

            request.InputStream = localFilePath;
            request.CannedACL = S3CannedACL.PublicReadWrite;
            utility.Upload(request);

            return true;
        }

        private void DelFilesToS3(string bucketName, string fileName)
        {

            AmazonS3Config config = new AmazonS3Config();
            config.ServiceURL = "s3.amazonaws.com";
            AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

            DeleteObjectRequest request = new DeleteObjectRequest()
            {
                BucketName = bucketName,
                Key = fileName
            };
            S3Response response = s3Client.DeleteObject(request);

        }

        //public  DownloadFiles(string bucketName,string fileKey)
        //{

        //    AmazonS3Config config = new AmazonS3Config();

        //    config.ServiceURL = "s3.amazonaws.com";

        //    AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

        //    MemoryStream file = new MemoryStream();
        //    try
        //    {
        //        GetObjectResponse r = s3Client.GetObject(new GetObjectRequest()
        //        {
        //            BucketName = bucketName,
        //            Key = fileKey
        //        });
        //        try
        //        {
        //            long transferred = 0L;
        //            BufferedStream stream2 = new BufferedStream(r.ResponseStream);
        //            byte[] buffer = new byte[0x2000];
        //            int count = 0;
        //            while ((count = stream2.Read(buffer, 0, buffer.Length)) > 0)
        //            {
        //                file.Write(buffer, 0, count);
        //            }
        //        }
        //        finally
        //        {
        //        }
        //       return file;
        //    }
        //    catch (AmazonS3Exception)
        //    {
        //        //Show exception
        //    }

        //}

        public void DownloadObject(string bucketName, string keyName)
        {

            AmazonS3Config config = new AmazonS3Config();
            config.ServiceURL = "s3.amazonaws.com";
            AmazonS3Client s3Client = new AmazonS3Client(PublicKey, SecretKey, config);

            string[] keySplit = keyName.Split('/');
            string fileName = keySplit[keySplit.Length - 1];
            string dest = Path.Combine(HttpRuntime.CodegenDir, fileName);

            GetObjectRequest request = new GetObjectRequest().WithBucketName(bucketName).WithKey(keyName);

            using (GetObjectResponse response = s3Client.GetObject(request))
            {
                response.WriteResponseStreamToFile(dest);
            }

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.ContentType = "application/octet-stream";

            HttpContext.Current.Response.TransmitFile(dest);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

            File.Delete(dest);

        }


    }
}