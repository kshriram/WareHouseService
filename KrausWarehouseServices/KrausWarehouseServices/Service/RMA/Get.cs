using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.RMA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Get" in both code and config file together.
    public class Get : IGet
    {

        #region Declaration
        //create User Object
        DBLogics.RMA.cmdUser _user = new DBLogics.RMA.cmdUser();

        //Create RMAComment Object
        DBLogics.RMA.cmdRMAComment _comment = new DBLogics.RMA.cmdRMAComment();

        //create Return object
        DBLogics.RMA.cmdReturn _return = new DBLogics.RMA.cmdReturn();

        //create ReturnDetail object
        DBLogics.RMA.cmdReturnDetail _returnDetail = new DBLogics.RMA.cmdReturnDetail();

        //create Reason object
        DBLogics.RMA.cmdReasons _reason = new DBLogics.RMA.cmdReasons();

        //create ReasonCategory object
        DBLogics.RMA.cmdReasonCategory _reasonCat = new DBLogics.RMA.cmdReasonCategory();

        //create Role object
        DBLogics.RMA.cmdRoles _role = new DBLogics.RMA.cmdRoles();

        //create SKUNumber object
        DBLogics.RMA.cmdSKUReasons _SKUreasons = new DBLogics.RMA.cmdSKUReasons();

        //Audit commands .
        DBLogics.RMA.cmdRMAAudit _audit = new DBLogics.RMA.cmdRMAAudit();

        //sage Operations Object.
        DBLogics.RMA.cmdSage _sageOperations = new DBLogics.RMA.cmdSage();

        //returnimages Object.
        DBLogics.RMA.cmdReturnImages _returnimages = new DBLogics.RMA.cmdReturnImages();

        //EDIFile Object.
        DBLogics.RMA.cmdEDIFileHandling _returnEDIFiles = new DBLogics.RMA.cmdEDIFileHandling();

        /// <summary>
        /// VersionReleased table commnads.
        /// </summary>
        DBLogics.RMA.cmdVersionReleased _VersionReleased = new DBLogics.RMA.cmdVersionReleased();

        #endregion

        #region User

        public List<DTO.Shipping.UserDTO> XMLUserGet(string EnumGetType, string Parameters)
        {
            //Convert to the Get Enum type.
            Globle_Classes.get Getid;
            Enum.TryParse(EnumGetType, true, out Getid);

            switch ((int)Getid)
            {
                case 0:
                    return this.UserAll();

                case 1:
                    Guid UserID;
                    Guid.TryParse(Parameters, out UserID);
                    List<DTO.Shipping.UserDTO> _lsReturnDTO = new List<DTO.Shipping.UserDTO>();
                    _lsReturnDTO.Add(this.UserByUserID(UserID));
                    return _lsReturnDTO;

                case 2:
                    Guid RoleID;
                    Guid.TryParse(Parameters, out RoleID);
                    return this.UserByRoleID(RoleID);

                case 3:
                    List<DTO.Shipping.UserDTO> _lsReturnDTO2 = new List<DTO.Shipping.UserDTO>();
                    _lsReturnDTO2.Add(this.UserByUserName(Parameters));
                    return _lsReturnDTO2;

                default:
                    List<DTO.Shipping.UserDTO> userDTO = new List<DTO.Shipping.UserDTO>();
                    return userDTO;
            }
        }

        public List<DTO.Shipping.UserDTO> UserAll()
        {
            return _user.GetUserTbl();
        }

        public DTO.Shipping.UserDTO UserByUserID(Guid UserID)
        {
            return _user.GetUserTbl1(UserID);
        }

        public List<DTO.Shipping.UserDTO> UserByRoleID(Guid RoleID)
        {
            return _user.GetUserByRoleID(RoleID);
        }

        public DTO.Shipping.UserDTO UserByUserName(string UserName)
        {
            return _user.GetUserTbl(UserName);
        }

        #endregion

        #region Return

        public List<DTO.RMA.ReturnDTO> XMLReturnGet(string ID, string Value)
        {
            //Convert to the Get Enum type.
            Globle_Classes.get Getid;
            Enum.TryParse(ID, true, out Getid);

            switch ((int)Getid)
            {
                case 0:
                    return this.ReturnAll();

                case 4:
                    Guid ReturnID;
                    Guid.TryParse(Value, out ReturnID);
                    List<DTO.RMA.ReturnDTO> _lsReturnDTO = new List<DTO.RMA.ReturnDTO>();
                    _lsReturnDTO.Add(this.ReturnByReturnID(ReturnID));
                    return _lsReturnDTO;

                case 5:
                    Guid ReturnDetailID;
                    Guid.TryParse(Value, out ReturnDetailID);
                    return this.ReturnByReturnDetailID(ReturnDetailID);

                case 6:
                    List<DTO.RMA.ReturnDTO> _lsReturnDTO2 = new List<DTO.RMA.ReturnDTO>();
                    _lsReturnDTO2.Add(this.ReturnByRMANumber(Value));
                    return _lsReturnDTO2;

                default:

                    return this.ReturnAll();
            }
        }

        public List<DTO.RMA.ReturnDTO> ReturnAll()
        {
            return _return.GetReturnTbl();
        }

        public DTO.RMA.ReturnDTO ReturnByReturnID(Guid ReturnID)
        {
            return _return.GetReturnTblByReturnID(ReturnID);
        }

        public DTO.RMA.ReturnDTO ReturnByRMANumber(string RMANumber)
        {
            return _return.GetReturnTblByRMANumber(RMANumber);
        }

        public List<DTO.RMA.ReturnDTO> ReturnByOrderNum(string OrderNum)
        {
            return _return.GetReturnTblByOrderNumber(OrderNum);
        }

        public List<DTO.RMA.ReturnDTO> ReturnByVendoeNum(string VendorNumber)
        {
            return _return.GetReturnTblByVenderNumber(VendorNumber);
        }

        public List<DTO.RMA.ReturnDTO> ReturnByVendorName(string VendorName)
        {
            return _return.GetReturnTblByVenderName(VendorName);
        }

        public List<DTO.RMA.ReturnDTO> ReturnByShipmentNumber(string ShipmentNumber)
        {
            return _return.GetReturnTblByShipmentNumber(ShipmentNumber);
        }

        public List<DTO.RMA.ReturnDTO> ReturnByPONumber(string PONumber)
        {
            return _return.GetReturnTblByPONumber(PONumber);
        }

        public List<DTO.RMA.ReturnDTO> ReturnByRGAROWID(string RGAROWID)
        {
            return _return.GetReturnTblByRGAROWID(RGAROWID);
        }

        public List<DTO.RMA.ReturnDTO> ReturnByRGADROWID(string RGADROWID)
        {
            return _return.GetReturnTblByRGADROWID(RGADROWID);
        }


        public List<DTO.RMA.ReturnDTO> ReturnByFromDateToDate(DateTime FromDate, DateTime ToDate)
        {
            return _return.GetReturnFromDateToDate(FromDate, ToDate);
        }

        public List<DTO.RMA.ReturnedSKUReasonPointsDTO> GetSKUReasonandPointsByReturnID(Guid ReturnID)
        {
            return _return.GetSKUandPointsByReturnID(ReturnID);
        }

        public List<DTO.RMA.ReturnedSKUReasonPointsDTO> GetSKUReasonandPointsByReturnDetailID(Guid ReturnDetailID)
        {
            return _return.GetSKUandPointsByReturnDetailID(ReturnDetailID);
        }


        #endregion

        #region Reason

        public List<DTO.RMA.ReasonsDTO> ReasonsAll()
        {
            return _reason.GetReasons();
        }

        public List<DTO.RMA.ReasonsDTO> ReasonByCategoryName(string CategoryName)
        {
            return _reason.GetReasonByCategoryName(CategoryName);
        }

        public string ListOfReasons(Guid ReturnDetailID)
        {
            return _SKUreasons.ListOfReasons(ReturnDetailID);
        }

        public List<DTO.RMA.ReasonsDTO> ReasonsByReturnDetailID(Guid ReaturnDetailsID)
        {
            return _reason.ListOfReasonsByReasonDetaailID(ReaturnDetailsID);
        }


        #endregion

        #region Audit
        public List<DTO.RMA.RMAAuditDTO> AuditAll()
        {
            return _audit.GetAudit();
        }
        #endregion

        #region Role
        public List<DTO.Shipping.RoleDTO> RoleAll()
        {
            return _role.GetRoles();
        }

        public DTO.Shipping.RoleDTO RoleByRoleID(Guid RoleID)
        {
            return _role.GetRoleTblByRoleID(RoleID);
        }
        #endregion

        #region Sage Operations

        public List<DTO.RMA.RMAInfoDTO> RMAInfoByShippingNumber(string ShippingNumber)
        {
            return _sageOperations.GetRMAInfoByShipmentNumber(ShippingNumber);
        }


        public List<DTO.RMA.RMAInfoDTO> RMAInfoBySONumber(string SONumber)
        {
            return _sageOperations.GetRMAInfoBySONumber(SONumber);
        }

        public List<DTO.RMA.RMAInfoDTO> RMAInfoByPONumber(string PONumber)
        {
            return _sageOperations.GetRMAInfoByPONumber(PONumber);
        }

        public List<DTO.RMA.RMAInfoDTO> NewRMAInfoByOnlyPONumber(string PONumber)
        {
            return _sageOperations.GetNewRMAInfoByOnlyPONumber(PONumber);
        }

        public List<DTO.RMA.RMAInfoDTO> RMAInfoByPONUmberwithSRNUmber(string PONumber)
        {
            return _sageOperations.GetRMAInfoByOnlyPONumberWithSRNUmber(PONumber);
        }


        public List<DTO.RMA.RMAInfoDTO> RMAInfoBySRNumber(string SRNumber)
        {
            return _sageOperations.GetRMAInfoBySRNumber(SRNumber);
        }

        public List<string> ProductMachingNameCat(string Chars)
        {
            return _sageOperations.GetNewRMAInfo(Chars);
        }

        public string GetEANCode(string Chars)
        {
            return _sageOperations.GetEANCodeByProductName(Chars);
        }

        public string GetProductName(string Char)
        {
            return _sageOperations.GetProductNameByEANCode(Char);
        }

        public string GetProductNameAndProductID(string Char)
        {
            return _sageOperations.GetProductNameAndProductIDByEANCode(Char);
        }

        public string GetPrintReasonFromSage(string SRnumber, string SKUNumber)
        {
            return _sageOperations.GetSageReasons(SRnumber, SKUNumber);
        }

        public List<DTO.RMA.RMAInfoDTO> GetCustomerByPOnumber(string POnumber)
        {
            return _sageOperations.GetCustomerByPONumber(POnumber);
        }

        public List<string> GetPOnumber(string chars)
        {
            return _sageOperations.GetPOnumber(chars);
        }

        public List<String> GetVenderName(String chars)
        {
            return _sageOperations.GetVendorName(chars);
        }


        public List<string> GetGetVenderNumber(string number)
        {
            return _sageOperations.GetVendorNumber(number);
        }
        public string GetVenderNameByVenderNumber(String VenderNumber)
        {
            return _sageOperations.GetVenderNameByVendorNumber(VenderNumber);
        }
        public string GetVenderNumberByVenderName(string VenderName)
        {
            return _sageOperations.GetVendorNumberByVenderName(VenderName);
        }




        #endregion

        #region Return Detail
        public List<DTO.RMA.ReturnDetailsDTO> ReturnDetailAll()
        {
            return _returnDetail.GetRetrunDetailsAll();
        }

        public List<DTO.RMA.ReturnDetailsDTO> ReturnDetailByretrnID(Guid RetunID)
        {
            return _returnDetail.GetreturnDetailByretrnID(RetunID);
        }
        public List<DTO.RMA.ReturnDetailsDTO> ReturnDetailByRetundetailID(Guid RetundetailID)
        {
            return _returnDetail.GetreturnDetailByRetunDetailID(RetundetailID);
        }

        public List<DTO.RMA.ReturnDetailsDTO> ReturnDetailByRGADROWID(string RGADROWID)
        {
            return _returnDetail.GetreturnDetailByRGADROWID(RGADROWID);
        }

        public List<DTO.RMA.ReturnDetailsDTO> ReturnDetailByRGAROWID(string RGAROWID)
        {
            return _returnDetail.GetreturnDetailByRGAROWID(RGAROWID);
        }
        #endregion

        #region ReturnImage.
        public List<DTO.RMA.ReturnImagesDTO> ImagePathTable(Guid ReturnDetailID)
        {
            return _returnimages.PathImage(ReturnDetailID);
        }

        public List<String> ImagePathStringList(Guid ReturnDetailID)
        {
            return _returnimages.PathImageStringList(ReturnDetailID);
        }

        #endregion

        public List<DTO.RMA.ReturnDTO> ReturnByReturnDetailID(Guid ReturnDetailsID)
        {
            return null;
        }

        #region Version Released for RGA

        public string GetRMALatestVersionNumber()
        {
            return _VersionReleased.GetNewVersionNumber();
        }

        #endregion

        #region SKUReasons

        public List<DTO.RMA.SKUReasonsDTO> GetSKUImagesByReturnDetailID(Guid ReturnDetailID)
        {
            return _SKUreasons.GetSKUReasonsByReturnDetailsID(ReturnDetailID);
        }

        #endregion
        public List<DTO.RMA.ReasonCategoryDTO> CategotyReasonNameByReasonID(Guid ReasonID)
        {
            return _reasonCat.ByReasonID(ReasonID);
        }

        public List<DTO.RMA.ReasonCategoryDTO> CategotyReasonAll()
        {
            return _reasonCat.All();
        }


        #region RMAcomment

        public List<DTO.RMA.RMACommentDTO> GetRMAComments(Guid RertunID)
        {
            return _comment.GetReturnTbl(RertunID);
        }

        #endregion

        #region
        public Boolean DeletePathImage(Guid ReturnDetailID, string SKUImagePath)
        {
            return _returnimages.DeletePathImageS(ReturnDetailID, SKUImagePath);
        }
        #endregion

        #region TodayReturns
        //public List<DTO.RMA.ReturnWithStringDTO> ReturnTodays()
        //{
        //    return _sageOperations.GetReturnForTodays();
        //}

        //public List<DTO.RMA.ReturnWithStringDTO> ReturnTodays()
        //{
        //    return _sageOperations.GetReturnForTodays();
        //}

        public List<DTO.RMA.ReturnWithStringDTO> ReturnTodaysinstring()
        {
            return _sageOperations.GetReturnForTodays();

        }
        public List<DTO.RMA.ReturnWithStringDTO> GetRetrunDetailByReturnIDforTrackingSearch(Guid returnID)
        {
            return _sageOperations.GetRetrunDetailByReturnIDforTrackingSearch(returnID);

        }

        public List<DTO.RMA.ReturnDetails> GetTrackingNumbersInReturnDetails()
        {
            return _returnDetail.GetTrackingNumbersInReturnDetails();
        }
        public List<DTO.RMA.ReturnWithStringDTO> GetRetrunDetailByTextforTrackingSearch(string text)
        {
            return _sageOperations.GetRetrunDetailByTextforTrackingSearch(text);

        }
        #endregion

        #region PendingDecision
        public List<DTO.RMA.ReturnWithStringDTO> ReturnPending()
        {
            return _sageOperations.GetReturnForPendingDecision();
        }

        #endregion

        #region ReturnAllString

        public List<DTO.RMA.ReturnWithStringDTO> ReturnAllString()
        {
            return _sageOperations.GetReturnAllWithString();
        }

        #endregion


        #region ReturnEDIFile

        public string[] filenames()
        {
            return _returnEDIFiles.filename();
        }

        public string GetfileData(string fnm)
        {
            return _returnEDIFiles.fileData(fnm);
        }
        public string fileDelete(string fnm)
        {
            return _returnEDIFiles.fileDelete(fnm);
        }


        public string sample(string fnm)
        {
            return _returnEDIFiles.sample(fnm);
        }
        public int MoveFiles(String filename)
        {
            return _returnEDIFiles.MoveFiles(filename);
        }

        public int Moves850MultiFiles()
        {
            return _returnEDIFiles.Move850Files();
        }

        public string[] FileNames850archive()
        {
            return _returnEDIFiles.FileNames850archive();
        }

        public string FileDataFrom850archive(string FileName)
        {
            return _returnEDIFiles.FileDataFrom850archive(FileName);
        }

        public string[] FilesNameFrom856Export()
        {
            return _returnEDIFiles.FilesNameFrom856Export();
        }

        public string FileDataFromExportError(string FileName)
        {
            return _returnEDIFiles.FileDataFrom856Export(FileName);
        }

        public int CreateOutFiles(String Filename, string Filedata)
        {
            return _returnEDIFiles.CreateFiles(Filename, Filedata);
        }

        public int CreateHomeDepotFilesFrom850(String Filename, string Filedata)
        {
            return _returnEDIFiles.CreateHomeDepotFilesFrom850(Filename, Filedata);
        }

        public int CreateHomeDepotFilesFrom856(String Filename, string Filedata)
        {
            return _returnEDIFiles.CreateHomeDepotFilesFrom856(Filename, Filedata);
        }

        public string FileDataFromHomeDepot850(string FileName)
        {
            return _returnEDIFiles.FileDataFromHomeDepot850(FileName);
        }

        public string FileDataFromHomeDepot856(string FileName)
        {
            return _returnEDIFiles.FileDataFromHomeDepot856(FileName);
        }

        public string[] FilenamesFromHomeDepot850()
        {
            return _returnEDIFiles.FilenamesFromHomeDepot850();
        }

        public string[] FilenamesFromHomeDepot856()
        {
            return _returnEDIFiles.FilenamesFromHomeDepot856();
        }

        public int CreateOverwriteOriginalFile(String Filename, string Filedata)
        {
            return _returnEDIFiles.OverwriteOriginalFile(Filename, Filedata);
        }

        public int Overwrite856HomeDepotFile(String Filename, string Filedata)
        {
            return _returnEDIFiles.Overwrite856HomeDepotFile(Filename, Filedata);
        }


        public int MovesFilesToTC(string FileName)
        {
            return _returnEDIFiles.MoveFilesToTC(FileName);
        }

        public int MoveSingleTrackingFilesToTC(string FileName)
        {
            return _returnEDIFiles.MoveSingleTrackingFilesToTC(FileName);
        }


        #endregion


        public string FileDataFrom856Export(string FileName)
        {
            return _returnEDIFiles.FileDataFrom856Export(FileName);
        }

        public int CreateAndMoveTrackingFileToTC(String Filename, string Filedata)
        {
            return _returnEDIFiles.CreateAndMoveTrackingFileToTC(Filename, Filedata);
        }


        #region Menard
        public string[] FilesNameFrom856ExportTCOutboxError()
        {
            return _returnEDIFiles.FilesNameFrom856ExportTCOutboxError();
        }

        public int MoveFilesFromTCOErrToMenardErr(String filename)
        {
            return _returnEDIFiles.MoveFilesFromTCOErrToMenardErr(filename);
        }

        public string FileDataFrom856exportTCOutboxError(string FileName)
        {
            return _returnEDIFiles.FileDataFrom856exportTCOutboxError(FileName);
        }

        public int CreateFilesFrom856ExportTCOutboxError(String Filename, string Filedata)
        {
            return _returnEDIFiles.CreateFilesFrom856ExportTCOutboxError(Filename, Filedata);
        }

        public string[] FilesNameFromMenardExportTCOutboxError()
        {
            return _returnEDIFiles.FilesNameFromMenardExportTCOutboxError();
        }


        #endregion



    }
}
