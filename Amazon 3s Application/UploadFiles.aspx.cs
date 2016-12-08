using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using FileStorageUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amazon_3s_Application
{
    public partial class UploadFiles : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {



            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            string accessKey = "put your access key here!";
            string secretKey = "put your secret key here!";

            AmazonS3Config config = new AmazonS3Config();

            config.ServiceURL = "objects.dreamhost.com";

            AmazonS3Client s3Client = new AmazonS3Client(accessKey, secretKey, config);


            PutBucketRequest request = new PutBucketRequest();
            request.BucketName = "my-new-bucket";
            s3Client.PutBucket(request);




          

        }
    }
}


//< input type = "hidden" name = "key" value = "@Model.FileId" />

//   < input type = "hidden" name = "AWSAccessKeyId" value = "@Model.AWSAccessKey" />

//        < input type = "hidden" name = "acl" value = "@Model.Acl" />

//             < input type = "hidden" name = "policy" value = "@Model.Base64EncodedPolicy" />

//                  < input type = "hidden" name = "signature" value = "@Model.Signature" />

//                       < input type = "hidden" name = "redirect" value = "@Model.RedirectUrl" />




//var fileStorageProvider = new AmazonS3FileStorageProvider();




//var fileUploadViewModel = new FileUpload(fileStorageProvider.PublicKey,
//                                                  fileStorageProvider.PrivateKey,
//                                                  fileStorageProvider.BucketName,
//                                                  string.Format("{0}home/complete", Request.Url.AbsoluteUri));

//fileUploadViewModel.SetPolicy(fileStorageProvider.GetPolicyString(
//                fileUploadViewModel.FileId, fileUploadViewModel.RedirectUrl));

//  return fileUploadViewModel;