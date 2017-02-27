﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductAccessor
    {

        ///<summary> 
        /// Dan Brown
        /// Created on 3/2/17
        ///
        /// Delete an individual product from the SnackOverflowDB product table (following documentation guidlines)
        ///</summary>
        ///<param name="productID"> The ID field of the product to be deleted </param>
        ///<returns> Returns rows affected (int) </returns>
        ///<exception cref="System.Exception"> Thrown if there is an error oppening a connection to the database </exception>
        public static int DeleteProduct(int productID)
        {
            int rowsAffected = 0;

            var cmdText = "@sp_delete_product";
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PRODUCT_ID", SqlDbType.Int);
            cmd.Parameters["@PRODUCT_ID"].Value = productID;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }


        /// <summary>
        /// Laura Simmonds
        /// Created on 2017/02/15
        /// 
        /// Retrieves a product from the database
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns>product</returns>

        public static Product RetrieveProductbyId(int ProductID)
        {
            {
                var product = new Product();

                var conn = DBConnection.GetConnection();
                var cmdText = @"sp_retrieve_product";
                var cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PRODUCT_ID", SqlDbType.Int);
                cmd.Parameters["@PRODUCT_ID"].Value = ProductID;

                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // ProductID, Name, Description, UnitPrice, ImageName, DeliveryChargePerUnit

                            product = new Product()
                            {
                                ProductId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                UnitPrice = reader.GetDecimal(3),
                                //ImageName = reader.GetString(4),
                                DeliveryChargePerUnit = reader.GetDecimal(5)
                            };
                        }
                        reader.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return product;
            }
        }



    }
}
