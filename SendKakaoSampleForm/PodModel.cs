using Dapper;
using Smes.AppConf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Smes.Models
{
    public class PodModel : RootModel
    {
        public List<PodModel> Lists;


        public PodModel()
        {

        }


        public PodModel(int PodId)
        {
                this.PodId = PodId;
        }


        public PodModel(PodModel pm)
        {
            this.PodId = pm.PodId;
        }

        public PodModel(PodWorkerModel pum)
        {
            this.PodId= pum.PodId;
        }

        public PodModel(string ErpCode)
        {
            this.PoErpCode = ErpCode;
        }


        #region Properties

        public int      PodId               { get; set; }
        public string   PodName             { get; set; }
        public int?     PoSdId              { get; set; }
        public int?     PoSggId             { get; set; }
        public string   PoAddress           { get; set; }
        public string   PoCorporateNumber   { get; set; }
        public string   PoPhone             { get; set; }
        public string   PoFax               { get; set; }
        public string   PoBusinessType      { get; set; }
        public string   PoBusinessItem      { get; set; }
        public string   PoEmailForTax       { get; set; }
        public string   PoCeo               { get; set; }
        public string   PoCeoCellphone      { get; set; }
        public string   PoCeoEmail          { get; set; }
        public string   PoErpCode           { get; set; }
        public bool     PoDeleted           { get; set; }
        public string   PoSdName            { get; set; }
        public string   PoSggName           { get; set; }


        #endregion



        public virtual int Add(IDbTransaction transaction = null)
        {
            int cnt = 0;

            ProcedureName = "SP_Pod_Add";

            var parameters = new DynamicParameters();

            parameters.Add("@PodId", DbType.String, direction: ParameterDirection.ReturnValue);
            parameters.Add("@PodName", value: PodName, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoSdId", value: PoSdId, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@PoSggId", value: PoSggId, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@PoAddress", value: PoAddress, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoCorporateNumber", value: PoCorporateNumber, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoPhone", value: PoPhone, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoFax", value: PoFax, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoBusinessType", value: PoBusinessType, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoBusinessItem", value: PoBusinessItem, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoEmailForTax", value: PoEmailForTax, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoCeo", value: PoCeo, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoCeoCellphone", value: PoCeoCellphone, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoCeoEmail", value: PoCeoEmail, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoDeleted", value: PoDeleted, DbType.Boolean, direction: ParameterDirection.Input);
            parameters.Add("@PoRegisterId", value: EnvGlobal.PodWorker.PodWorkerId, DbType.Int32, direction: ParameterDirection.Input);

            try
            {
                cnt = Connection.Execute(ProcedureName, parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                PodId = parameters.Get<int>("@PodId");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cnt;
        }


        public virtual int Update(IDbTransaction transaction = null)
        {
            ProcedureName = "SP_Pod_Update";
            
            var parameters = new DynamicParameters();

            parameters.Add("@PodId", value: PodId, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@PodName", value: PodName, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoSdId", value: PoSdId, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@PoSggId", value: PoSggId, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@PoAddress", value: PoAddress, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoCorporateNumber", value: PoCorporateNumber, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoPhone", value: PoPhone, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoFax", value: PoFax, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoBusinessType", value: PoBusinessType, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoBusinessItem", value: PoBusinessItem, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoEmailForTax", value: PoEmailForTax, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoCeo", value: PoCeo, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoCeoCellphone", value: PoCeoCellphone, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoCeoEmail", value: PoCeoEmail, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@PoDeleted", value: PoDeleted, DbType.Boolean, direction: ParameterDirection.Input);
            parameters.Add("@PoLastModifierId", value: EnvGlobal.PodWorker.PodWorkerId, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@PoLastModifiedDate", value: DateTime.Now, DbType.DateTime, direction: ParameterDirection.Input);

            try
            {
                cnt = Connection.Execute(ProcedureName, parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cnt;
        }



        public virtual int Delete(IDbTransaction transaction = null)
        {
            int cnt = 0;

            ProcedureName = "SP_Pod_Delete";

            var parameters = new DynamicParameters();

            parameters.Add("@PodId", value: PodId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            try
            {
                cnt = Connection.Execute(ProcedureName, parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cnt;
        }


        public virtual List<PodModel> GetById(IDbTransaction transaction = null)
        {
            ProcedureName = "SP_Pod_GetById";

            var parameters = new DynamicParameters();

            parameters.Add("@PodId", value: PodId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            try
            {
                Lists = Connection.Query<PodModel>(ProcedureName, parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lists;
        }


        public virtual List<PodModel> GetAll(IDbTransaction transaction = null)
        {
            ProcedureName = "SP_Pod_GetAll";

            var parameters = new DynamicParameters();

            try
            {
                Lists = Connection.Query<PodModel>(ProcedureName, parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lists;
        }


        public virtual List<PodModel> GetByName(bool ShowDeletedPod, IDbTransaction transaction = null)
        {
            ProcedureName = "SP_Pod_GetByName";

            var parameters = new DynamicParameters();

            parameters.Add("@PodName", value: PodName, dbType: DbType.String, direction: ParameterDirection.Input);

            try
            {
                Lists = Connection.Query<PodModel>(ProcedureName, parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lists;
        }
    }
}
