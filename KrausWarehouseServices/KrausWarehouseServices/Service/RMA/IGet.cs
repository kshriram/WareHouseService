using KrausWarehouseServices.DTO.RMA;
using KrausWarehouseServices.DTO.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KrausWarehouseServices.Service.RMA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGet" in both code and config file together.
    [ServiceContract]
    public interface IGet
    {

        #region User

        /// <summary>
        /// XML return user information.
        /// </summary>
        /// <param name="EnumGetTypeString">
        /// Function call ID
        /// ID examples: USERID/ROLEID/LOGINNAME/GETALL.
        /// </param>
        /// <param name="Parameters">
        /// parametes to respective ID passed. in string.
        /// </param>
        /// <returns>
        /// list of UserDTO table information.
        /// </returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/User?ID={EnumGetTypeString}&value={Parameters}", Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<UserDTO> XMLUserGet(String EnumGetTypeString, String Parameters);

        /// <summary>
        /// SOA function return all user table.
        /// </summary>
        /// <returns>
        /// list of UserDTO table information.
        /// </returns>
        [OperationContract]
        List<UserDTO> UserAll();


        /// <summary>
        /// Filter information by UserID.
        /// </summary>
        /// <param name="UserID">
        /// Guid UserID
        /// </param>
        /// <returns>
        /// UserDTO Information.
        /// </returns>
        [OperationContract]
        UserDTO UserByUserID(Guid UserID);


        /// <summary>
        /// Filter user information by RoleID
        /// </summary>
        /// <param name="RoleID">
        /// Guid RoelID.
        /// </param>
        /// <returns>
        /// List of userDTO information matched to the Role.
        /// </returns>
        [OperationContract]
        List<UserDTO> UserByRoleID(Guid RoleID);

        /// <summary>
        /// Search user information matched to the User Name and password.
        /// </summary>
        /// <param name="UserName">
        /// String User Name.(Login User namae.)
        /// </param>
        /// <param name="Password">
        /// String password.
        /// </param>
        /// <returns>
        /// UserDTO with information.
        /// </returns>
        [OperationContract]
        UserDTO UserByUserName(String UserName);



        #endregion

        #region Return

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Return?ID={ID}&value={value}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ReturnDTO> XMLReturnGet(String ID, String value);

        [OperationContract]
        List<ReturnDTO> ReturnAll();

        [OperationContract]
        ReturnDTO ReturnByReturnID(Guid ReturnID);


        [OperationContract]
        List<ReturnedSKUReasonPointsDTO> GetSKUReasonandPointsByReturnID(Guid ReturnID);

        [OperationContract]
        List<ReturnedSKUReasonPointsDTO> GetSKUReasonandPointsByReturnDetailID(Guid ReturnDetailID);


        [OperationContract]
        List<ReturnDTO> ReturnByReturnDetailID(Guid ReturnDetailsID);

        [OperationContract]
        ReturnDTO ReturnByRMANumber(String RMANumber);

        [OperationContract]
        List<ReturnDTO> ReturnByOrderNum(String OrderNum);

        [OperationContract]
        List<ReturnDTO> ReturnByVendoeNum(String VendorNumber);

        [OperationContract]
        List<ReturnDTO> ReturnByVendorName(String VendorName);

        [OperationContract]
        List<ReturnDTO> ReturnByShipmentNumber(String ShipmentNumber);

        [OperationContract]
        List<ReturnDTO> ReturnByPONumber(String PONumber);

        [OperationContract]
        List<ReturnDTO> ReturnByRGAROWID(String RGAROWID);

        [OperationContract]
        List<ReturnDTO> ReturnByRGADROWID(String RGADROWID);


        //[OperationContract]
        //List<ReturnWithStringDTO> ReturnTodays();


        //[OperationContract]
        //List<ReturnWithStringDTO> ReturnTodays();

        [OperationContract]
        List<ReturnWithStringDTO> ReturnTodaysinstring();

        [OperationContract]
        List<ReturnWithStringDTO> ReturnPending();

        [OperationContract]
        List<ReturnWithStringDTO> ReturnAllString();

        [OperationContract]
        List<ReturnWithStringDTO> GetRetrunDetailByReturnIDforTrackingSearch(Guid returnID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ReturnByFromDateToDate?ID={FromDate}&value={ToDate}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ReturnDTO> ReturnByFromDateToDate(DateTime FromDate, DateTime ToDate);
        #endregion

        #region Return Details.

        [OperationContract]
        List<DTO.RMA.ReturnDetailsDTO> ReturnDetailAll();

        [OperationContract]
        List<ReturnDetailsDTO> ReturnDetailByretrnID(Guid RetunID);


        [OperationContract]
        List<ReturnDetailsDTO> ReturnDetailByRetundetailID(Guid RetundetailID);

        [OperationContract]
        List<ReturnDetailsDTO> ReturnDetailByRGADROWID(String RGADROWID);

        [OperationContract]
        List<ReturnDetailsDTO> ReturnDetailByRGAROWID(String RGAROWID);

        [OperationContract]
        List<ReturnDetails> GetTrackingNumbersInReturnDetails();
        [OperationContract]
        List<ReturnWithStringDTO> GetRetrunDetailByTextforTrackingSearch(string text);
        #endregion

        #region Reason

        [OperationContract]
        List<ReasonsDTO> ReasonsAll();

        [OperationContract]
        List<ReasonsDTO> ReasonByCategoryName(String CategoryName);

        [OperationContract]
        String ListOfReasons(Guid ReturnDetail);

        [OperationContract]
        List<ReasonsDTO> ReasonsByReturnDetailID(Guid ReaturnDetailsID);

        #endregion

        #region Audit

        [OperationContract]
        List<RMAAuditDTO> AuditAll();

        #endregion

        #region Sage Operations

        [OperationContract]
        List<RMAInfoDTO> RMAInfoByShippingNumber(String ShippingNumber);

        [OperationContract]
        List<RMAInfoDTO> RMAInfoBySONumber(String SONumber);

        [OperationContract]
        List<RMAInfoDTO> RMAInfoByPONumber(String PONumber);

        [OperationContract]
        List<RMAInfoDTO> NewRMAInfoByOnlyPONumber(String PONumber);

        [OperationContract]
        List<RMAInfoDTO> RMAInfoByPONUmberwithSRNUmber(String POnmumber);


        [OperationContract]
        List<RMAInfoDTO> RMAInfoBySRNumber(String SRNumber);

        [OperationContract]
        List<string> ProductMachingNameCat(string Chars);

        [OperationContract]
        string GetEANCode(string Chars);

        [OperationContract]
        string GetProductName(string CharEAN);

        [OperationContract]
        string GetProductNameAndProductID(string CharEAN);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetPrintReasonFromSage?ID={SRnumber}&value={SKUNumber}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetPrintReasonFromSage(string SRnumber, String SKUNumber);


        [OperationContract]
        List<RMAInfoDTO> GetCustomerByPOnumber(string POnumber);


        [OperationContract]
        List<string> GetPOnumber(string chars);

        [OperationContract]
        List<string> GetVenderName(String chars);

        [OperationContract]
        List<string> GetGetVenderNumber(string number);

        [OperationContract]
        string GetVenderNameByVenderNumber(string vendernumber);

        [OperationContract]
        string GetVenderNumberByVenderName(string vendername);

        #endregion

        #region Role
        [OperationContract]
        List<RoleDTO> RoleAll();

        [OperationContract]
        RoleDTO RoleByRoleID(Guid RoleID);

        #endregion

        #region image return
        [OperationContract]
        List<ReturnImagesDTO> ImagePathTable(Guid ReturnDetailID);


        [OperationContract]
        List<String> ImagePathStringList(Guid ReturnDetailID);

        [OperationContract(Name = "Authenticate")]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Authenticate")]
        Boolean DeletePathImage(Guid ReturnDetailID, string SKUImagePath);
        #endregion

        #region Version Released for RGA

        [OperationContract]
        String GetRMALatestVersionNumber();


        #endregion

        #region SKUImages

        [OperationContract]
        List<SKUReasonsDTO> GetSKUImagesByReturnDetailID(Guid ReturnDetailID);

        #endregion

        #region ReasonCatagoty
        [OperationContract]
        List<ReasonCategoryDTO> CategotyReasonNameByReasonID(Guid ReasonID);

        [OperationContract]
        List<ReasonCategoryDTO> CategotyReasonAll();

        #endregion

        #region RMAcomment
        [OperationContract]
        List<RMACommentDTO> GetRMAComments(Guid ReturnID);
        #endregion


        #region EDIFiles
        [OperationContract]
        string[] filenames();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetfileData?ID={filename}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetfileData(string filename);

        [OperationContract]
        string fileDelete(string filename);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/sample?ID={fnm}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string sample(string fnm);

        [OperationContract]
        int MoveFiles(String filename);

        [OperationContract]
        int Moves850MultiFiles();

        [OperationContract]
        string[] FileNames850archive();


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FileDataFrom850archive?ID={FileName}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string FileDataFrom850archive(string FileName);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FileDataFrom856Export?ID={FileName}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string FileDataFrom856Export(string FileName);


        [OperationContract]
        string[] FilesNameFrom856Export();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CreateOutFiles?FileName={FileName}&FileData={FileData}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        int CreateOutFiles(string FileName, string FileData);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CreateHomeDepotFilesFrom850?FileName={FileName}&FileData={FileData}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        int CreateHomeDepotFilesFrom850(string FileName, string FileData);



        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CreateHomeDepotFilesFrom856?FileName={FileName}&FileData={FileData}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        int CreateHomeDepotFilesFrom856(string FileName, string FileData);



        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FileDataFromHomeDepot850?ID={FileName}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string FileDataFromHomeDepot850(string FileName);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FileDataFromHomeDepot856?ID={FileName}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string FileDataFromHomeDepot856(string FileName);


        [OperationContract]
        string[] FilenamesFromHomeDepot850();

        [OperationContract]
        string[] FilenamesFromHomeDepot856();



        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CreateOverwriteOriginalFile?FileName={FileName}&FileData={FileData}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        int CreateOverwriteOriginalFile(string FileName, string FileData);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Overwrite856HomeDepotFile?FileName={FileName}&FileData={FileData}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        int Overwrite856HomeDepotFile(string FileName, string FileData);



        [OperationContract]
        int MovesFilesToTC(String filename);

        [OperationContract]
        int MoveSingleTrackingFilesToTC(String filename);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CreateAndMoveTrackingFileToTC?FileName={FileName}&FileData={FileData}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        int CreateAndMoveTrackingFileToTC(string FileName, string FileData);
        #endregion


        #region Menard

        [OperationContract]
        string[] FilesNameFrom856ExportTCOutboxError();

        [OperationContract]
        int MoveFilesFromTCOErrToMenardErr(String filename);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FileDataFrom856exportTCOutboxError?ID={FileName}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string FileDataFrom856exportTCOutboxError(string FileName);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CreateFilesFrom856ExportTCOutboxError?FileName={FileName}&FileData={FileData}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        int CreateFilesFrom856ExportTCOutboxError(string FileName, string FileData);


        [OperationContract]
        string[] FilesNameFromMenardExportTCOutboxError();


        #endregion


       
    }
}
