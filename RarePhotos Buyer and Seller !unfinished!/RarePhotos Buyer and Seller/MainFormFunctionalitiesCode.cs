using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RarePhotos_Buyer_and_Seller
{
    public partial class MainForm : Form
    {


        private void InitFileDialogSettings()
        {
            FileDialogUploadPhoto.InitialDirectory = "C://Desktop";
            FileDialogUploadPhoto.RestoreDirectory = true;
            FileDialogUploadPhoto.Title = "Select photo to be upload.";
            FileDialogUploadPhoto.Filter = "Select Valid Document(*.png; *.jpg; *.jpeg;)|*.png; *.jpg; *.jpeg;";
            FileDialogUploadPhoto.FilterIndex = 1;
            FileDialogUploadPhoto.CheckFileExists = true;
            FileDialogUploadPhoto.CheckPathExists = true;
            FileDialogUploadPhoto.Multiselect = false;
        }

        private void performUploading(string path)
        {
            if (CloudinaryProxy == null)
            {
                MessageBox.Show("CloudinaryProxy object is null in MainForm..");
                return;
            }
            else
            {
                string URL = CloudinaryProxy.UploadPhoto(path, LoggedInUser.UserName, LoggedInUser.UserName);
                int PhotoID = DataBaseProxy.InsertNewPhoto(LoggedInUser.UserName,URL);
                DataBaseProxy.InsertPhotoToCollection(LoggedInUser.ID,PhotoID);
                MessageBox.Show("The Photo was uploaded successfully to our server (cloudinary)");
            }
        }

        private void UploadPhoto()
        {
            try
            {
                if (FileDialogUploadPhoto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (FileDialogUploadPhoto.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(FileDialogUploadPhoto.FileName);

                        //if( every component is good ) then perfomUploadig(path);
                        performUploading(path);
                        // else message...
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload photo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}











