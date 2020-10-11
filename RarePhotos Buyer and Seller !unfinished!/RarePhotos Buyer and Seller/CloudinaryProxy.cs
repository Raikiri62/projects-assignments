using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace RarePhotos_Buyer_and_Seller
{
    public class CloudinaryProxy
    {
        private Account m_Account;
        private Cloudinary m_Cloudinary;
        public CloudinaryProxy()
        {
            m_Account = new Account(
            "dyuqrnb07",
            "667111718288426",
            "yVJFAbQpglr-M7SRxkhH_9AoQFE");
            m_Cloudinary = new Cloudinary(m_Account);
        }

        public string UploadPhoto(string i_Path,string i_Username,string i_Tag)
        {
            var uploadParams = new ImageUploadParams() //                PublicId = "RarePhotos/" + i_Username,
            {
                File = new FileDescription(i_Path),
                Folder = "RarePhotos/" + i_Username,
                Tags = i_Tag
            };
            var uploadResult = m_Cloudinary.Upload(uploadParams);
            return uploadResult.Url.ToString();
        }
    }
}
