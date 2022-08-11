using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Contract
{
    public interface IDBOperation
    {
        public DataTable GetTable(string CommandText);
        public DataTable GetTable(string CommandText, SqlConnection Con);
        public DataTable GetTable(string CommandText, SqlConnection Con, SqlTransaction tx);
        public DataTable GetTable(string CommandText, String ConnectionString);
        public DataTable GetTable(string CommandText, DataTable dt);
        public Object GetScalar(string CommandText);
        public void ExecuteQuery(string CommandText);
        public int Query(string CommandText);
        public int Query(string CommandText, SqlConnection con, SqlTransaction tx);
        public int QueryIDreturn(string CommandText, SqlConnection con, SqlTransaction tx);
        public void ExecuteQuery(string CommandText, SqlConnection con, SqlTransaction tx);
        Task<int> GetVtype(string vtype);
        Task<int> GetApprovalID(int k, string vtype, int AccountID);
        Task<int> GetBranchID(int vid);
        public DataTable GetUserInfo(String UserName, String ConnectionString);
        Task<int> GetNextNo(int vtype, int branchId);
        public String GetUserAuthenticated(String UserName, String Password, String ConnectionString);

        Task<string> GetBudget(long AccId, string Fiancialyear, int branchId);
        public String NewNumber(int vtype, DateTime d, int _BranchId);

        public String PasswordDecode(string Pwd);
        public String PasswordEncode(string Pwd);


    }
}
