using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
    public class RMACommentDTO
    {
        [DataMember]
        public Guid RMACommentID { get; set; }
        
       [DataMember]
         public Guid? ReturnID { get; set; }
      
       [DataMember]
       public Guid? UserID { get; set; }
     
       [DataMember]
       public DateTime? CommentDate { get; set; }

       [DataMember]
       public String Comment { get; set; }
       
           
      
       public RMACommentDTO()
       {
           //Blank Constructor.
       }

       public RMACommentDTO(RMACommentDTO Comments)
       {
           if (Comments.RMACommentID != null) this.RMACommentID =(Guid)Comments.UserID;
           if (Comments.ReturnID != null) this.ReturnID = Comments.ReturnID;
           if (Comments.UserID != null) this.UserID = Comments.UserID;
           if (Comments.CommentDate != Convert.ToDateTime("01/01/0001")) this.CommentDate = (DateTime)Comments.CommentDate;
           if (Comments.Comment != null) this.Comment = (String)Comments.Comment;
       }
    }
}
