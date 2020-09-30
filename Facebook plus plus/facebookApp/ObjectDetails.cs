using System;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebookApp
{
    public abstract class ObjectDetails
    {
        public FacebookObject ObjectModel { get; set; }

        public Dictionary<string, string> DetailsDictionary { get; set; }

        public ObjectDetails()
        {
            DetailsDictionary = new Dictionary<string, string>();
        }

        public abstract void extractDetailsFromObject();
    }

    public class PostDetails : ObjectDetails
    {
        public PostDetails(FacebookObject i_ObjectModel) : base()
        {
            ObjectModel = i_ObjectModel;
            extractDetailsFromObject();
        }

        public string[] Comments { get; set; }

        public override void extractDetailsFromObject()
        {
            Post post = ObjectModel as Post;
            DetailsDictionary.Add("Name", post.Name);
            DetailsDictionary.Add("Caption", post.Caption);
            DetailsDictionary.Add("Message", post.Message);
            DetailsDictionary.Add("Description", post.Description);
            Comments = new string[post.Comments.Count];
            for (int i = 0; i < post.Comments.Count; i++)
            {
                Comments[i] = post.Comments[i].Message;
            }
        }
    }

    public class FriendDetails : ObjectDetails
    {
        public FriendDetails(FacebookObject i_ObjectModel) : base()
        {
            ObjectModel = i_ObjectModel;
            extractDetailsFromObject();
        }

        public string[] Posts { get; set; }

        public override void extractDetailsFromObject()
        {
            User user = ObjectModel as User;
            DetailsDictionary.Add("Name", user.Name);
            if (user.Location != null && user.Location.Name != null)
            {
                DetailsDictionary.Add("Hometown", user.Location.Name);
            }
            else
            {
                DetailsDictionary.Add("Hometown", "Unknown");
            }

            DetailsDictionary.Add("PictureURL", user.PictureNormalURL);
            DetailsDictionary.Add("Birthday", user.Birthday);
            Posts = new string[user.Posts.Count];

            for (int i = 0; i < user.Posts.Count; i++)
            {
                if (user.Posts[i].Message != null)
                {
                    Posts[i] = user.Posts[i].Message;
                }
                else if (user.Posts[i].Caption != null)
                {
                    Posts[i] = user.Posts[i].Caption;
                }
                else
                {
                    Posts[i] = string.Format("[{0}]", user.Posts[i].Type);
                }
            }
        }
    }

    public class ObjectDetailsFactory
    {
        public ObjectDetails getObjectDetails(FacebookObject i_ObjectModel)
        {
            if (i_ObjectModel.GetType() == typeof(Post))
            {
                return new PostDetails(i_ObjectModel);
            }
            else if (i_ObjectModel.GetType() == typeof(User))
            {
                return new FriendDetails(i_ObjectModel);
            }

            return null;
        }
    }
}
