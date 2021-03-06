﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class VoucherRepository : _Repository
    {
        public VoucherRepository()
        {
            this.Table = "Vouchers";
        }

        public bool ValidateVoucher(String voucher)
        {
            try
            {
                String Query = String.Format("SELECT COUNT(*) AS Count FROM {0} WHERE Codigo = '{1}' AND Estado = 'A'", this.Table, voucher);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return int.Parse(this.SqlDataReader["Count"].ToString()) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlConnection.Close();
            }
        }

        public void SaveRaffle(String voucher, int productId, int userId)
        {
            try
            {
                String Query = String.Format("UPDATE {0} SET IdUsuario = {1}, IdProducto = {2}, Estado = 'B' WHERE Codigo = '{3}'",
                                             this.Table,
                                             userId,
                                             productId,
                                             voucher);
                this.ExecUpdate(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlConnection.Close();
            }
        }
    }
}
