using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace Smes.Models
{
    public class CustomerModel 
    {
        public new List<CustomerModel> Lists;

        public CustomerModel()
        {
            
        }

        public CustomerModel(string CustomerName)
        {
            
        }


        //고객공통
        public int          CtPodId             { get; set; }
        public int          CustomerId          { get; set; }
        public string       CustomerName        { get; set; }
        public string       CtPhone             { get; set; }
        public string       CtEmail             { get; set; }
        public int?         CtSdId              { get; set; }
        public string       CtSdName            { get; set; }
        public int?         CtSggId             { get; set; }
        public string       CtSggName           { get; set; }
        public string       CtAddress           { get; set; }
        public string       CtPostalCode        { get; set; }
        public int?         CtCustomerGroupId   { get; set; }
        public string       CtCustomerGroupName { get; set; }
        public int?         CtCustomerLevelId   { get; set; }
        public string       CtCustomerLevelName { get; set; }
        public bool         CtIsPartner         { get; set; }
        public bool         CtIsDealer          { get; set; }
        public bool         CtIsCompany         { get; set; } = true;
        public string       CtMemo              { get; set; }
        //기업고객
        public string       CtCeo               { get; set; }
        public string       CtCeoCellphone      { get; set; }
        public string       CtCeoEmail          { get; set; }
        public string       CtCorporateNumber   { get; set; }
        public string       CtBusinessType      { get; set; }
        public string       CtBusinessItem      { get; set; }
        public string       CtEmailForTax       { get; set; }
        public string       CtWorker            { get; set; }
        public string       CtWorkerPhone       { get; set; }
        public string       CtWorkerAddress     { get; set; }
        //관리속성
        public int          CtRegisterId        { get; set; }
        public string       CtRegisterName      { get; set; }
        public DateTime     CtRegistedDate      { get; set; }
        public int?         CtLastModifierId    { get; set; }
        public string       CtLastModifierName  { get; set; }
        public DateTime?    CtLastModifiedDate  { get; set; }
        
        public int          CtEstimateCount     { get; set; }
        public int          CtOrderCount        { get; set; }

   
    }
}
