using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebookApp
{
    public class PostContent
    {
        public PostContent(Post i_Post)
        {
            Name = i_Post.Name;
            Caption = i_Post.Caption;
            Message = i_Post.Message;
            Description = i_Post.Description;
            Comments = new string[i_Post.Comments.Count];

            for(int i = 0; i < i_Post.Comments.Count; i++)
            {
                Comments[i] = i_Post.Comments[i].Message;
            }
        }

        public string Name { get; set; }

        public string Caption { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }

        public string[] Comments { get; set; }
    }
}
