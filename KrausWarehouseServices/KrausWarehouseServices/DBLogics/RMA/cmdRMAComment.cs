using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO;
using KrausWarehouseServices.DTO.RMA;
using System.Data.Objects;

namespace KrausWarehouseServices.DBLogics.RMA
{
    public class cmdRMAComment
    {
        Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

        #region GetComment
        public List<RMACommentDTO> GetReturnTbl(Guid RertunID)
        {
            List<RMACommentDTO> _return = new List<RMACommentDTO>();

            try
            {
                var re = (from commentTable in entRMA.RMAComments
                          where commentTable.ReturnID == RertunID
                          select commentTable).ToList();

                foreach (var item in re)
                {
                    RMACommentDTO redto = new RMACommentDTO();
                    redto.Comment = item.Comment;
                    redto.RMACommentID = item.RMACommentID;
                    redto.ReturnID = item.ReturnID;
                    redto.UserID = item.UserID;
                    redto.CommentDate = item.CommentDate;
                    _return.Add(redto);
                }
            }
            catch (Exception)
            {
            }
            return _return;
        }
        #endregion


        #region SetComment

        public Boolean insertComment(RMACommentDTO comments)
        {
            Boolean flag = false;
            try
            {
                  RMAComment  _commentObj = new RMAComment();

                  _commentObj.Comment = comments.Comment;
                  _commentObj.CommentDate = comments.CommentDate;
                  _commentObj.UserID = comments.UserID;
                  _commentObj.ReturnID = comments.ReturnID;
                  _commentObj.RMACommentID = comments.RMACommentID;

                  entRMA.AddToRMAComments(_commentObj);
                  entRMA.SaveChanges();
                  flag = true;
            }
            catch (Exception)
            {
            }
            return flag;

        
        }


        #endregion


    }
}
