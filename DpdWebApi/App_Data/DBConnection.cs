using drug;
using DpdWebApi.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;

namespace drug
{
    public class DBConnection
    {

        private string _lang;
        public string Lang
        {
            get { return this._lang; }
            set { this._lang = value; }
        }

        public DBConnection(string lang)
        {
            this._lang = lang;
        }

        private string DpdDBConnection
        {
            get { return ConfigurationManager.ConnectionStrings["dpd"].ToString(); }
        }
    
        
        public DrugProduct GetDrugProductById(int id, string lang, string status)
        {
            var companyCode = "";
            var drugProduct = new DrugProduct();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT A";
            
            if (status.Length > 0 && id > 0)
            {
                commandText += " , DPD_ONLINE_OWNER.WQRY_STATUS B WHERE A.DRUG_CODE = " + id;
                commandText += "  AND A.DRUG_CODE = B.DRUG_CODE AND B.EXTERNAL_STATUS_CODE = " + status;
            }
            else
            {
                commandText += " WHERE A.DRUG_CODE = " + id;
            }
            
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new DrugProduct();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.class_name = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
                                item.drug_identification_number = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
                                if (lang.Equals("fr"))
                                {
                                    item.descriptor = dr["DESCRIPTOR_F"] == DBNull.Value ? dr["DESCRIPTOR"].ToString().Trim() : dr["DESCRIPTOR_F"].ToString().Trim();
                                    item.brand_name = dr["BRAND_NAME_F"] == DBNull.Value ? dr["BRAND_NAME"].ToString().Trim() : dr["BRAND_NAME_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.descriptor = dr["DESCRIPTOR"] == DBNull.Value ? dr["DESCRIPTOR_F"].ToString().Trim() : dr["DESCRIPTOR"].ToString().Trim();
                                    item.brand_name = dr["BRAND_NAME"] == DBNull.Value ? dr["BRAND_NAME_F"].ToString().Trim() : dr["BRAND_NAME"].ToString().Trim();
                                }
                                item.number_of_ais = dr["NUMBER_OF_AIS"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NUMBER_OF_AIS"]);
                                item.ai_group_no = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
                                companyCode = dr["COMPANY_CODE"] == DBNull.Value ? string.Empty : dr["COMPANY_CODE"].ToString().Trim();
                                Company company = new Company();
                                company = GetCompanyByCompanyCode(Int32.Parse(companyCode), lang);
                                if (company != null)
                                {
                                    item.company = company;
                                }
                                drugProduct = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetDrugProductByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return drugProduct;
        }

        public List<DrugProduct> GetAllDrugProduct(string lang, string status = "")
        {
            var companyCode = "";
            var orderClause = "";
            var items = new List<DrugProduct>();
            string commandText = "SELECT DISTINCT A.* FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT A";
            if (status.Length > 0)
            {
                commandText += " , DPD_ONLINE_OWNER.WQRY_STATUS B WHERE A.DRUG_CODE = B.DRUG_CODE AND B.EXTERNAL_STATUS_CODE = " + status;
            }

            commandText += " ORDER BY" + orderClause + " A.DRUG_IDENTIFICATION_NUMBER";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new DrugProduct();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.class_name = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
                                item.drug_identification_number = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
                                if (lang.Equals("fr"))
                                {
                                    item.descriptor = dr["DESCRIPTOR_F"] == DBNull.Value ? dr["DESCRIPTOR"].ToString().Trim() : dr["DESCRIPTOR_F"].ToString().Trim();
                                    item.brand_name = dr["BRAND_NAME_F"] == DBNull.Value ? dr["BRAND_NAME"].ToString().Trim() : dr["BRAND_NAME_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.descriptor = dr["DESCRIPTOR"] == DBNull.Value ? dr["DESCRIPTOR_F"].ToString().Trim() : dr["DESCRIPTOR"].ToString().Trim();
                                    item.brand_name = dr["BRAND_NAME"] == DBNull.Value ? dr["BRAND_NAME_F"].ToString().Trim() : dr["BRAND_NAME"].ToString().Trim();
                                }

                                item.number_of_ais = dr["NUMBER_OF_AIS"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NUMBER_OF_AIS"]);
                                item.ai_group_no = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
                                companyCode = dr["COMPANY_CODE"] == DBNull.Value ? string.Empty : dr["COMPANY_CODE"].ToString().Trim();
                                Company company = new Company();
                                company = GetCompanyByCompanyCode(Int32.Parse(companyCode), lang);
                                if (company != null)
                                {
                                    item.company = company;
                                }
                                items.Add(item);
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllDrugProduct()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        //public oldDrugProductbk GetDrugProductByDrugCode(int id, string lang)
        //{
        //    var drugProduct = new oldDrugProductbk();
        //    string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT WHERE DRUG_CODE = " + id;
        //    using (OracleConnection con = new OracleConnection(DpdDBConnection))
        //    {
        //        OracleCommand cmd = new OracleCommand(commandText, con);
        //        try
        //        {
        //            con.Open();
        //            using (OracleDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                     var item  = new oldDrugProductbk();
        //                        item.AiGroupNo = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
        //                        if (lang.Equals("fr"))
        //                        {
        //                            item.BrandName = dr["BRAND_NAME_F"] == DBNull.Value ? string.Empty : dr["BRAND_NAME_F"].ToString().Trim();
        //                            item.Class = dr["CLASS_F"] == DBNull.Value ? string.Empty : dr["CLASS_F"].ToString().Trim();
        //                            item.Descriptor = dr["DESCRIPTOR_F"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR_F"].ToString().Trim();
        //                        }
        //                        else {
        //                            item.BrandName = dr["BRAND_NAME"] == DBNull.Value ? string.Empty : dr["BRAND_NAME"].ToString().Trim();
        //                            //item.BrandNameF = dr["BRAND_NAME_F"] == DBNull.Value ? string.Empty : dr["BRAND_NAME_F"].ToString().Trim();
        //                            item.Class = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
        //                            //item.ClassF = dr["CLASS_F"] == DBNull.Value ? string.Empty : dr["CLASS_F"].ToString().Trim();
        //                            item.Descriptor = dr["DESCRIPTOR"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR"].ToString().Trim();


        //                        }
        //                        item.CompanyCode = dr["COMPANY_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["COMPANY_CODE"]);
        //                        item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
        //                        item.DrugIdentificationNumber = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
        //                        item.NumberOfAis = dr["NUMBER_OF_AIS"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUMBER_OF_AIS"]);

        //                        drugProduct = item;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string errorMessages = string.Format("DbConnection.cs - GetDrugProductByDrugCode()");
        //            ExceptionHelper.LogException(ex, errorMessages);
        //            Console.WriteLine(errorMessages);
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }
        //    }
        //    return drugProduct;
        //}

        //public oldDrugProductbk GetDrugProductByDin(String din, string lang)
        //{
        //    var drugProduct = new oldDrugProductbk();
        //    string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT WHERE DRUG_IDENTIFICATION_NUMBER = " + din;
        //    using (OracleConnection con = new OracleConnection(DpdDBConnection))
        //    {
        //        OracleCommand cmd = new OracleCommand(commandText, con);
        //        try
        //        {
        //            con.Open();
        //            using (OracleDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        var item = new oldDrugProductbk();
        //                        item.AiGroupNo = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
        //                        if (lang.Equals("fr"))
        //                        {
        //                            item.BrandName = dr["BRAND_NAME_F"] == DBNull.Value ? string.Empty : dr["BRAND_NAME_F"].ToString().Trim();
        //                            item.Class = dr["CLASS_F"] == DBNull.Value ? string.Empty : dr["CLASS_F"].ToString().Trim();
        //                            item.Descriptor = dr["STATUS_NAME"] == DBNull.Value ? string.Empty : dr["STATUS_NAME_F"].ToString().Trim();
        //                        }
        //                        else {
        //                            item.BrandName = dr["BRAND_NAME"] == DBNull.Value ? string.Empty : dr["BRAND_NAME"].ToString().Trim();
        //                            item.Class = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
        //                            item.Descriptor = dr["DESCRIPTOR"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR"].ToString().Trim();


        //                        }
        //                        item.CompanyCode = dr["COMPANY_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["COMPANY_CODE"]);
        //                        item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
        //                        item.DrugIdentificationNumber = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
        //                        item.NumberOfAis = dr["NUMBER_OF_AIS"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUMBER_OF_AIS"]);

        //                        drugProduct = item;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string errorMessages = string.Format("DbConnection.cs - GetDrugProductByDin()");
        //            ExceptionHelper.LogException(ex, errorMessages);
        //            Console.WriteLine(errorMessages);
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }
        //    }
        //    return drugProduct;
        //}

        public List<ActiveIngredient> GetAllActiveIngredient(string lang)
        {
            var items = new List<ActiveIngredient>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ACTIVE_INGREDIENTS";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item  = new ActiveIngredient();
   
                                if (lang.Equals("fr"))
                                {
                                    item.ingredient_name = dr["INGREDIENT_F"] == DBNull.Value ? dr["INGREDIENT"].ToString().Trim() : dr["INGREDIENT_F"].ToString().Trim();
                                    item.strength_unit = dr["STRENGTH_UNIT_F"] == DBNull.Value ? dr["STRENGTH_UNIT"].ToString().Trim() : dr["STRENGTH_UNIT_F"].ToString().Trim();
                                    item.dosage_unit = dr["DOSAGE_UNIT_F"] == DBNull.Value ? dr["DOSAGE_UNIT"].ToString().Trim() : dr["DOSAGE_UNIT_F"].ToString().Trim();
                                }
                                else {
                                    item.ingredient_name = dr["INGREDIENT"] == DBNull.Value ? dr["INGREDIENT_F"].ToString().Trim() : dr["INGREDIENT"].ToString().Trim();
                                    item.strength_unit = dr["STRENGTH_UNIT"] == DBNull.Value ? dr["STRENGTH_UNIT_F"].ToString().Trim() : dr["STRENGTH_UNIT"].ToString().Trim();
                                    item.dosage_unit = dr["DOSAGE_UNIT"] == DBNull.Value ? dr["DOSAGE_UNIT_F"].ToString().Trim() : dr["DOSAGE_UNIT"].ToString().Trim();
                                }
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["DRUG_CODE"]);
                                item.strength = dr["STRENGTH"] == DBNull.Value ? string.Empty : dr["STRENGTH"].ToString().Trim();
                                item.dosage_value = dr["DOSAGE_VALUE"] == DBNull.Value ? string.Empty : dr["DOSAGE_VALUE"].ToString().Trim();
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllActiveIngredients()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public ActiveIngredient GetActiveIngredientByDrugCode(int id, string lang)
        {
            var activeIngredient = new ActiveIngredient();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ACTIVE_INGREDIENTS WHERE DRUG_CODE = " + id;
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                             var item  = new ActiveIngredient();
                                if (lang.Equals("fr"))
                                {
                                    item.ingredient_name = dr["INGREDIENT_F"] == DBNull.Value ? dr["INGREDIENT"].ToString().Trim() : dr["INGREDIENT_F"].ToString().Trim();
                                    item.strength_unit = dr["STRENGTH_UNIT_F"] == DBNull.Value ? dr["STRENGTH_UNIT"].ToString().Trim() : dr["STRENGTH_UNIT_F"].ToString().Trim();
                                    item.dosage_unit = dr["DOSAGE_UNIT_F"] == DBNull.Value ? dr["DOSAGE_UNIT"].ToString().Trim() : dr["DOSAGE_UNIT_F"].ToString().Trim();
                                }
                                else {
                                    item.ingredient_name = dr["INGREDIENT"] == DBNull.Value ? dr["INGREDIENT_F"].ToString().Trim() : dr["INGREDIENT"].ToString().Trim();
                                    item.strength_unit = dr["STRENGTH_UNIT"] == DBNull.Value ? dr["STRENGTH_UNIT_F"].ToString().Trim() : dr["STRENGTH_UNIT"].ToString().Trim();
                                    item.dosage_unit = dr["DOSAGE_UNIT"] == DBNull.Value ? dr["DOSAGE_UNIT_F"].ToString().Trim() : dr["DOSAGE_UNIT"].ToString().Trim();
                                }
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.strength = dr["STRENGTH"] == DBNull.Value ? string.Empty : dr["STRENGTH"].ToString().Trim();
                                item.dosage_value = dr["DOSAGE_VALUE"] == DBNull.Value ? string.Empty : dr["DOSAGE_VALUE"].ToString().Trim();
                                activeIngredient = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetActiveIngredientById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return activeIngredient;
        }
    
        public List<Company> GetAllCompany(string lang)
        {
            var items = new List<Company>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_COMPANIES";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item  = new Company();
                                item.company_code = dr["COMPANY_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["COMPANY_CODE"]);
                                item.company_name = dr["COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["COMPANY_NAME"].ToString().Trim();
                                item.company_type = dr["COMPANY_TYPE"] == DBNull.Value ? string.Empty : dr["COMPANY_TYPE"].ToString().Trim();
                                item.suite_number = dr["SUITE_NUMNER"] == DBNull.Value ? string.Empty : dr["SUITE_NUMNER"].ToString().Trim();
                                item.city_name = dr["CITY_NAME"] == DBNull.Value ? string.Empty : dr["CITY_NAME"].ToString().Trim();
                                item.postal_code = dr["POSTAL_CODE"] == DBNull.Value ? string.Empty : dr["POSTAL_CODE"].ToString().Trim();
                                item.post_office_box = dr["POST_OFFICE_BOX"] == DBNull.Value ? string.Empty : dr["POST_OFFICE_BOX"].ToString().Trim();

                                if (lang.Equals("fr"))
                                {
                                    
                                    item.street_name = dr["STREET_NAME_F"] == DBNull.Value ? dr["INGREDIENT"].ToString().Trim() : dr["STREET_NAME_F"].ToString().Trim();
                                    item.province_name = dr["PROVINCE_F"] == DBNull.Value ? dr["INGREDIENT"].ToString().Trim() : dr["PROVINCE_F"].ToString().Trim();
                                    item.country_name = dr["COUNTRY_F"] == DBNull.Value ? dr["INGREDIENT"].ToString().Trim() : dr["COUNTRY_F"].ToString().Trim();
                                }
                                else {
                                    item.street_name = dr["STREET_NAME"] == DBNull.Value ? dr["STREET_NAME_F"].ToString().Trim() : dr["STREET_NAME"].ToString().Trim();
                                    item.province_name = dr["PROVINCE"] == DBNull.Value ? dr["PROVINCE_F"].ToString().Trim() : dr["PROVINCE"].ToString().Trim();
                                    item.country_name = dr["COUNTRY"] == DBNull.Value ? dr["COUNTRY_F"].ToString().Trim() : dr["COUNTRY"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllCompany()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public Company GetCompanyByCompanyCode(int id, string lang)
        {
            var company = new Company();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_COMPANIES WHERE COMPANY_CODE = " + id;
            using (
                
                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item  = new Company();
                                item.company_code = dr["COMPANY_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["COMPANY_CODE"]);
                                item.company_name = dr["COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["COMPANY_NAME"].ToString().Trim();
                                item.company_type = dr["COMPANY_TYPE"] == DBNull.Value ? string.Empty : dr["COMPANY_TYPE"].ToString().Trim();
                                item.suite_number = dr["SUITE_NUMNER"] == DBNull.Value ? string.Empty : dr["SUITE_NUMNER"].ToString().Trim();
                                item.city_name = dr["CITY_NAME"] == DBNull.Value ? string.Empty : dr["CITY_NAME"].ToString().Trim();
                                item.postal_code = dr["POSTAL_CODE"] == DBNull.Value ? string.Empty : dr["POSTAL_CODE"].ToString().Trim();
                                item.post_office_box = dr["POST_OFFICE_BOX"] == DBNull.Value ? string.Empty : dr["POST_OFFICE_BOX"].ToString().Trim();

                                if (lang.Equals("fr"))
                                {

                                    item.street_name = dr["STREET_NAME_F"] == DBNull.Value ? dr["INGREDIENT"].ToString().Trim() : dr["STREET_NAME_F"].ToString().Trim();
                                    item.province_name = dr["PROVINCE_F"] == DBNull.Value ? dr["INGREDIENT"].ToString().Trim() : dr["PROVINCE_F"].ToString().Trim();
                                    item.country_name = dr["COUNTRY_F"] == DBNull.Value ? dr["INGREDIENT"].ToString().Trim() : dr["COUNTRY_F"].ToString().Trim();
                                }
                                else {
                                    item.street_name = dr["STREET_NAME"] == DBNull.Value ? dr["STREET_NAME_F"].ToString().Trim() : dr["STREET_NAME"].ToString().Trim();
                                    item.province_name = dr["PROVINCE"] == DBNull.Value ? dr["PROVINCE_F"].ToString().Trim() : dr["PROVINCE"].ToString().Trim();
                                    item.country_name = dr["COUNTRY"] == DBNull.Value ? dr["COUNTRY_F"].ToString().Trim() : dr["COUNTRY"].ToString().Trim();
                                }
                                company = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetCompanyByCompanyCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return company;
        }
        
        public List<Route> GetAllRoute(string lang, string active = "")
        {
            var items = new List<Route>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ROUTE";
            if (active.ToUpper().Equals("YES"))
            {

                commandText = commandText + " WHERE INACTIVE_DATE IS NULL OR INACTIVE_DATE > SYSDATE";
            }
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Route();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.route_of_administration_code = dr["ROUTE_OF_ADMINISTRATION_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ROUTE_OF_ADMINISTRATION_CODE"]);
                                //item.inactive_date = dr["INACTIVE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["INACTIVE_DATE"]);

                                if (lang.Equals("fr"))
                                {
                                    item.route_of_administration_name = dr["ROUTE_OF_ADMINISTRATION_F"] == DBNull.Value ? dr["ROUTE_OF_ADMINISTRATION"].ToString().Trim() : dr["ROUTE_OF_ADMINISTRATION_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.route_of_administration_name = dr["ROUTE_OF_ADMINISTRATION"] == DBNull.Value ? dr["ROUTE_OF_ADMINISTRATION_F"].ToString().Trim() : dr["ROUTE_OF_ADMINISTRATION"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllRoute()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public Route GetRouteByDrugCode(int id, string lang, string active = "")
        {
            var route = new Route();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ROUTE WHERE DRUG_CODE = " + id;
            if (active.ToUpper().Equals("YES"))
            {
                commandText = commandText + " AND INACTIVE_DATE IS NULL OR INACTIVE_DATE > SYSDATE";
            }
            using (
            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Route();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.route_of_administration_code = dr["ROUTE_OF_ADMINISTRATION_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ROUTE_OF_ADMINISTRATION_CODE"]);
                                //item.inactive_date = dr["INACTIVE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["INACTIVE_DATE"]);

                                if (lang.Equals("fr"))
                                {
                                    item.route_of_administration_name = dr["ROUTE_OF_ADMINISTRATION_F"] == DBNull.Value ? dr["ROUTE_OF_ADMINISTRATION"].ToString().Trim() : dr["ROUTE_OF_ADMINISTRATION_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.route_of_administration_name = dr["ROUTE_OF_ADMINISTRATION"] == DBNull.Value ? dr["ROUTE_OF_ADMINISTRATION_F"].ToString().Trim() : dr["ROUTE_OF_ADMINISTRATION"].ToString().Trim();
                                }
                                route = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetRouteByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return route;
        }

        public List<Status> GetAllStatus(string lang)
        {
            var items = new List<Status>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_STATUS S, DPD_ONLINE_OWNER.WQRY_STATUS_EXTERNAL ES";
            commandText += " WHERE S.EXTERNAL_STATUS_CODE = ES.EXTERNAL_STATUS_CODE";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Status();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.history_date = dr["HISTORY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["HISTORY_DATE"]);
                                item.external_status_code = dr["EXTERNAL_STATUS_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["EXTERNAL_STATUS_CODE"]);
                                item.original_market_date = dr["ORIGINAL_MARKET_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ORIGINAL_MARKET_DATE"]);
                                item.expiration_date = dr["EXPIRATION_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["EXPIRATION_DATE"]);
                                item.lot_number = dr["LOT_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["LOT_NUMBER"]);

                                if (lang.Equals("fr"))
                                {
                                    item.status = dr["EXTERNAL_STATUS_FRENCH"] == DBNull.Value ? dr["EXTERNAL_STATUS_ENGLISH"].ToString().Trim() : dr["EXTERNAL_STATUS_FRENCH"].ToString().Trim();
                                }
                                else
                                {
                                    item.status = dr["EXTERNAL_STATUS_ENGLISH"] == DBNull.Value ? dr["EXTERNAL_STATUS_FRENCH"].ToString().Trim() : dr["EXTERNAL_STATUS_ENGLISH"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllStatus()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public Status GetStatusByDrugCode(int id, string lang)
        {
            var status = new Status();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_STATUS S, DPD_ONLINE_OWNER.WQRY_STATUS_EXTERNAL ES";
            commandText += " WHERE DRUG_CODE = " + id + " AND S.EXTERNAL_STATUS_CODE = ES.EXTERNAL_STATUS_CODE";
            
            using (
            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Status();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.history_date = dr["HISTORY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["HISTORY_DATE"]);
                                item.external_status_code = dr["EXTERNAL_STATUS_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["EXTERNAL_STATUS_CODE"]);
                                item.original_market_date = dr["ORIGINAL_MARKET_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ORIGINAL_MARKET_DATE"]);
                                item.expiration_date = dr["EXPIRATION_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["EXPIRATION_DATE"]);
                                item.lot_number = dr["LOT_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["LOT_NUMBER"]);

                                if (lang.Equals("fr"))
                                {
                                    item.status = dr["EXTERNAL_STATUS_FRENCH"] == DBNull.Value ? dr["EXTERNAL_STATUS_ENGLISH"].ToString().Trim() : dr["EXTERNAL_STATUS_FRENCH"].ToString().Trim();
                                }
                                else
                                {
                                    item.status = dr["EXTERNAL_STATUS_ENGLISH"] == DBNull.Value ? dr["EXTERNAL_STATUS_FRENCH"].ToString().Trim() : dr["EXTERNAL_STATUS_ENGLISH"].ToString().Trim();
                                }
                                status = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetStatusByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return status;
        }
     
        public List<Form> GetAllForm(string lang, string active = "")
        {
            var items = new List<Form>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_FORM";
            if (active.ToUpper().Equals("YES"))
            {
                commandText = commandText + " WHERE INACTIVE_DATE IS NULL OR INACTIVE_DATE > SYSDATE";
            }
            
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Form();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                //item.inactive_date = dr["INACTIVE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["INACTIVE_DATE"]);
                                item.pharmaceutical_form_code = dr["PHARMACEUTICAL_FORM_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PHARMACEUTICAL_FORM_CODE"]);
                                if (lang.Equals("fr"))
                                {
                                    item.pharmaceutical_form_name = dr["PHARMACEUTICAL_FORM_F"] == DBNull.Value ? dr["PHARMACEUTICAL_FORM"].ToString().Trim() : dr["PHARMACEUTICAL_FORM_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.pharmaceutical_form_name = dr["PHARMACEUTICAL_FORM"] == DBNull.Value ? dr["PHARMACEUTICAL_FORM_F"].ToString().Trim() : dr["PHARMACEUTICAL_FORM"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllForm()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public Form GetFormByDrugCode(int id, string lang, string active = "")
        {
            var form = new Form();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_FORM WHERE DRUG_CODE = " + id;
            if (active.ToUpper().Equals("YES"))
            {
                commandText = commandText + " AND INACTIVE_DATE IS NULL OR INACTIVE_DATE > SYSDATE";
            }
            using (
            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Form();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                //item.inactive_date = dr["INACTIVE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["INACTIVE_DATE"]);
                                item.pharmaceutical_form_code = dr["PHARMACEUTICAL_FORM_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PHARMACEUTICAL_FORM_CODE"]);
                                if (lang.Equals("fr"))
                                {
                                    item.pharmaceutical_form_name = dr["PHARMACEUTICAL_FORM_F"] == DBNull.Value ? dr["PHARMACEUTICAL_FORM"].ToString().Trim() : dr["PHARMACEUTICAL_FORM_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.pharmaceutical_form_name = dr["PHARMACEUTICAL_FORM"] == DBNull.Value ? dr["PHARMACEUTICAL_FORM_F"].ToString().Trim() : dr["PHARMACEUTICAL_FORM"].ToString().Trim();
                                }
                                form = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetFormByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return form;
        }

        public List<Packaging> GetAllPackaging(string lang)
        {
            var items = new List<Packaging>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_PACKAGING";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Packaging();
                                //item.packaging_id = dr["WQRY_PACKAGING_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WQRY_PACKAGING_ID"]);
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.upc = dr["UPC"] == DBNull.Value ? string.Empty : dr["UPC"].ToString().Trim();
                                item.package_size_unit = dr["PACKAGE_SIZE_UNIT"] == DBNull.Value ? string.Empty : dr["PACKAGE_SIZE_UNIT"].ToString().Trim();
                                item.package_type = dr["PACKAGE_TYPE"] == DBNull.Value ? string.Empty : dr["PACKAGE_TYPE"].ToString().Trim();
                                item.package_size = dr["PACKAGE_SIZE"] == DBNull.Value ? string.Empty : dr["PACKAGE_SIZE"].ToString().Trim();
                                item.product_information = dr["PRODUCT_INFORMATION"] == DBNull.Value ? string.Empty : dr["PRODUCT_INFORMATION"].ToString().Trim();
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllPackaging()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public Packaging GetPackagingByDrugCode(int id, string lang)
        {
            var packaging = new Packaging();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_PACKAGING WHERE WQRY_PACKAGING_ID = " + id;
            using (
            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Packaging();
                                //item.packaging_id = dr["WQRY_PACKAGING_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WQRY_PACKAGING_ID"]);
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.upc = dr["UPC"] == DBNull.Value ? string.Empty : dr["UPC"].ToString().Trim();
                                item.package_size_unit = dr["PACKAGE_SIZE_UNIT"] == DBNull.Value ? string.Empty : dr["PACKAGE_SIZE_UNIT"].ToString().Trim();
                                item.package_type = dr["PACKAGE_TYPE"] == DBNull.Value ? string.Empty : dr["PACKAGE_TYPE"].ToString().Trim();
                                item.package_size = dr["PACKAGE_SIZE"] == DBNull.Value ? string.Empty : dr["PACKAGE_SIZE"].ToString().Trim();
                                item.product_information = dr["PRODUCT_INFORMATION"] == DBNull.Value ? string.Empty : dr["PRODUCT_INFORMATION"].ToString().Trim();

                                packaging = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetPackagingByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return packaging;
        }

        public List<PharmaceuticalStd> GetAllPharmaceuticalStd()
        {
            var items = new List<PharmaceuticalStd>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_PHARMACEUTICAL_STD";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new PharmaceuticalStd();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.pharmaceutical_std = dr["PHARMACEUTICAL_STD"] == DBNull.Value ? string.Empty : dr["PHARMACEUTICAL_STD"].ToString().Trim();
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllPharmaceuticalStd()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public PharmaceuticalStd GetPharmaceuticalStdByDrugCode(int id)
        {
            var pharmaceuticalstd = new PharmaceuticalStd();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_PHARMACEUTICAL_STD WHERE DRUG_CODE = " + id;
            using (
            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new PharmaceuticalStd();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.pharmaceutical_std = dr["PHARMACEUTICAL_STD"] == DBNull.Value ? string.Empty : dr["PHARMACEUTICAL_STD"].ToString().Trim();
                                
                                pharmaceuticalstd = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetPharmaceuticalStdByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return pharmaceuticalstd;
        }
        
        public List<Schedule> GetAllSchedule(string lang, string active = "")
        {
            var items = new List<Schedule>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_SCHEDULE";
            if (active.ToUpper().Equals("YES"))
            {
                commandText = commandText + " WHERE INACTIVE_DATE IS NULL OR INACTIVE_DATE > SYSDATE";
            }
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Schedule();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                //item.schedule_code = dr["SCHEDULE_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SCHEDULE_CODE"]);
                                //item.inactive_date = dr["INACTIVE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["INACTIVE_DATE"]);
                                if (lang.Equals("fr"))
                                {
                                    item.schedule_name = dr["SCHEDULE_F"] == DBNull.Value ? dr["SCHEDULE"].ToString().Trim() : dr["SCHEDULE_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.schedule_name = dr["SCHEDULE"] == DBNull.Value ? dr["SCHEDULE_F"].ToString().Trim() : dr["SCHEDULE"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllSchedule()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public Schedule GetScheduleByDrugCode(int id, string lang, string active = "")
        {
            var schedule = new Schedule();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_SCHEDULE WHERE DRUG_CODE = " + id;
            if (active.ToUpper().Equals("YES"))
            {
                commandText = commandText + " AND INACTIVE_DATE IS NULL OR INACTIVE_DATE > SYSDATE";
            }
            using (
            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Schedule();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                //item.schedule_code = dr["SCHEDULE_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SCHEDULE_CODE"]);
                                //item.inactive_date = dr["INACTIVE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["INACTIVE_DATE"]);
                                if (lang.Equals("fr"))
                                {
                                    item.schedule_name = dr["SCHEDULE_F"] == DBNull.Value ? dr["SCHEDULE"].ToString().Trim() : dr["SCHEDULE_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.schedule_name = dr["SCHEDULE"] == DBNull.Value ? dr["SCHEDULE_F"].ToString().Trim() : dr["SCHEDULE"].ToString().Trim();
                                }
                                schedule = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetScheduleByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return schedule;
        }

        public List<TherapeuticClass> GetAllTherapeuticClass(string lang)
        {
            var items = new List<TherapeuticClass>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ATC A, DPD_ONLINE_OWNER.WQRY_AHFS B";
            commandText += " WHERE A.DRUG_CODE = B.DRUG_CODE";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new TherapeuticClass();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.tc_atc_number = dr["TC_ATC_NUMBER"] == DBNull.Value ? string.Empty : dr["TC_ATC_NUMBER"].ToString().Trim();
                                item.tc_ahfs_number = dr["TC_AHFS_NUMBER"] == DBNull.Value ? string.Empty : dr["TC_AHFS_NUMBER"].ToString().Trim();
                                if (lang.Equals("fr"))
                                {
                                    item.tc_atc = dr["TC_ATC_F"] == DBNull.Value ? dr["TC_ATC"].ToString().Trim() : dr["TC_ATC_F"].ToString().Trim();
                                    item.tc_ahfs = dr["TC_AHFS_F"] == DBNull.Value ? dr["TC_AHFS"].ToString().Trim() : dr["TC_AHFS_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.tc_atc = dr["TC_ATC"] == DBNull.Value ? dr["TC_ATC_F"].ToString().Trim() : dr["TC_ATC"].ToString().Trim();
                                    item.tc_ahfs = dr["TC_AHFS"] == DBNull.Value ? dr["TC_AHFS_F"].ToString().Trim() : dr["TC_AHFS"].ToString().Trim();
                                }
                                
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllTherapeuticClass()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public TherapeuticClass GetTherapeuticClassByDrugCode(int id, string lang)
        {
            var therapeuticClass = new TherapeuticClass();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ATC A, DPD_ONLINE_OWNER.WQRY_AHFS B";
            commandText += " WHERE A.DRUG_CODE = B.DRUG_CODE AND A.DRUG_CODE = " + id;
            using (
            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new TherapeuticClass();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.tc_atc_number = dr["TC_ATC_NUMBER"] == DBNull.Value ? string.Empty : dr["TC_ATC_NUMBER"].ToString().Trim();
                                item.tc_ahfs_number = dr["TC_AHFS_NUMBER"] == DBNull.Value ? string.Empty : dr["TC_AHFS_NUMBER"].ToString().Trim();
                                if (lang.Equals("fr"))
                                {
                                    item.tc_atc = dr["TC_ATC_F"] == DBNull.Value ? dr["TC_ATC"].ToString().Trim() : dr["TC_ATC_F"].ToString().Trim();
                                    item.tc_ahfs = dr["TC_AHFS_F"] == DBNull.Value ? dr["TC_AHFS"].ToString().Trim() : dr["TC_AHFS_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.tc_atc = dr["TC_ATC"] == DBNull.Value ? dr["TC_ATC_F"].ToString().Trim() : dr["TC_ATC"].ToString().Trim();
                                    item.tc_ahfs = dr["TC_AHFS"] == DBNull.Value ? dr["TC_AHFS_F"].ToString().Trim() : dr["TC_AHFS"].ToString().Trim();
                                }
                                therapeuticClass = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetTherapeuticClassByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return therapeuticClass;
        }

        public List<VeterinarySpecies> GetAllVeterinarySpecies(string lang)
        {
            var items = new List<VeterinarySpecies>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_DRUG_VETERINARY_SPECIES";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
            OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new VeterinarySpecies();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                //item.vet_species_code = dr["VET_SPECIES_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VET_SPECIES_CODE"]);
                                if (lang.Equals("fr"))
                                {
                                    item.vet_species_name = dr["VET_SPECIES_F"] == DBNull.Value ? dr["VET_SPECIES"].ToString().Trim() : dr["VET_SPECIES_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.vet_species_name = dr["VET_SPECIES"] == DBNull.Value ? dr["VET_SPECIES_F"].ToString().Trim() : dr["VET_SPECIES"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllDrugVeterinarySpecies()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public VeterinarySpecies GetVeterinarySpeciesByDrugCode(int id, string lang)
        {
            var veterinarySpecies = new VeterinarySpecies();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_DRUG_VETERINARY_SPECIES WHERE DRUG_CODE = " + id;
            using (
            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new VeterinarySpecies();
                                item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                //item.vet_species_code = dr["VET_SPECIES_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VET_SPECIES_CODE"]);
                                if (lang.Equals("fr"))
                                {
                                    item.vet_species_name = dr["VET_SPECIES_F"] == DBNull.Value ? dr["VET_SPECIES"].ToString().Trim() : dr["VET_SPECIES_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.vet_species_name = dr["VET_SPECIES"] == DBNull.Value ? dr["VET_SPECIES_F"].ToString().Trim() : dr["VET_SPECIES"].ToString().Trim();
                                }
                                veterinarySpecies = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetDrugVeterinarySpeciesByDrugCode()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return veterinarySpecies;
        }
    }

    /// KEEP if we decide to do the search for DPD
    //public DrugProduct GetDrugProductById(int id, string lang)
    //{
    //    var drugProduct = new DrugProduct();
    //    string commandText = "SELECT A.DRUG_CODE, A.DRUG_IDENTIFICATION_NUMBER, A.NUMBER_OF_AIS, A.AI_GROUP_NO, A.COMPANY_CODE,";
    //    commandText += " C.ORIGINAL_MARKET_DATE, C.HISTORY_DATE, C.EXTERNAL_STATUS_CODE, E.DOSAGE_VALUE, E.DOSAGE_UNIT, E.STRENGTH, ";
    //    if (lang.Equals("fr"))
    //    {
    //        commandText += " A.BRAND_NAME, A.BRAND_NAME_F, A.CLASS_F as CLASS, EX.EXTERNAL_STATUS_FRENCH as STATUS, D.SCHEDULE_F as SCHEDULE, H.TC_AHFS_F AS AHFS, T.TC_ATC AS ATC, E.INGREDIENT_F as INGREDIENT,";
    //        commandText += " E.STRENGTH_UNIT_F as STRENGTH_UNIT, F.PHARMACEUTICAL_FORM_F as FORM_NAME, pm.PM_FRENCH_FNAME as PM_NAME,";
    //        commandText += " R.ROUTE_OF_ADMINISTRATION_F as ROUTE_NAME";
    //    }
    //    else {
    //        commandText += " A.BRAND_NAME, A.BRAND_NAME_F, A.CLASS, EX.EXTERNAL_STATUS_ENGLISH as STATUS, D.SCHEDULE, F.PHARMACEUTICAL_FORM as FORM_NAME, H.TC_AHFS AS AHFS, T.TC_ATC AS ATC, E.INGREDIENT, E.STRENGTH_UNIT,";
    //        commandText += " pm.PM_ENGLISH_FNAME as PM_NAME, R.ROUTE_OF_ADMINISTRATION as ROUTE_NAME";
    //    }
    //    commandText += " FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT A";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_STATUS C on A.DRUG_CODE = C.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_STATUS_EXTERNAL EX on C.EXTERNAL_STATUS_CODE = EX.EXTERNAL_STATUS_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_SCHEDULE D on A.DRUG_CODE = D.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_FORM F on A.DRUG_CODE = F.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_ROUTE R on A.DRUG_CODE = R.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_AHFS H on A.DRUG_CODE = H.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_ATC T on A.DRUG_CODE = T.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_ACTIVE_INGREDIENTS E on A.DRUG_CODE = E.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_PM_DRUG pm ON A.DRUG_CODE = pm.DRUG_CODE";
    //    commandText += " WHERE E.id = (select min(id) from DPD_ONLINE_OWNER.wqry_active_ingredients E where A.drug_code = E.drug_code) AND A.DRUG_CODE = " + id;

    //    using (OracleConnection con = new OracleConnection(DpdDBConnection))
    //    {
    //        OracleCommand cmd = new OracleCommand(commandText, con);
    //        try
    //        {
    //            con.Open();
    //            using (OracleDataReader dr = cmd.ExecuteReader())
    //            {
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        var item = new DrugProduct();
    //                        if (lang.Equals("fr"))
    //                        {
    //                            item.brand_name = dr["BRAND_NAME_F"] == DBNull.Value ? dr["BRAND_NAME_F"].ToString().Trim() : dr["BRAND_NAME"].ToString().Trim();
    //                        }
    //                        else
    //                        {
    //                            item.brand_name = dr["BRAND_NAME"] == DBNull.Value ? dr["BRAND_NAME"].ToString().Trim() : dr["BRAND_NAME_F"].ToString().Trim();
    //                        }
    //                        item.class_name = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
    //                        item.status_name = dr["STATUS"] == DBNull.Value ? string.Empty : dr["STATUS"].ToString().Trim();
    //                        item.schedule_name = dr["SCHEDULE"] == DBNull.Value ? string.Empty : dr["SCHEDULE"].ToString().Trim();
    //                        item.ai_name = dr["INGREDIENT"] == DBNull.Value ? string.Empty : dr["INGREDIENT"].ToString().Trim();
    //                        item.strength = dr["STRENGTH"] == DBNull.Value ? string.Empty : dr["STRENGTH"].ToString().Trim();
    //                        item.strength_unit_name = dr["STRENGTH_UNIT"] == DBNull.Value ? string.Empty : dr["STRENGTH_UNIT"].ToString().Trim();
    //                        item.ai_group_no = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
    //                        item.number_of_ais = dr["NUMBER_OF_AIS"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NUMBER_OF_AIS"]);
    //                        //item.company_name = dr["COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["COMPANY_NAME"].ToString().Trim();
    //                        //item.street_name = dr["STREET_NAME"] == DBNull.Value ? string.Empty : dr["STREET_NAME"].ToString().Trim();
    //                        //item.city_name = dr["CITY_NAME"] == DBNull.Value ? string.Empty : dr["CITY_NAME"].ToString().Trim();
    //                        //item.country_name = dr["COUNTRY_NAME"] == DBNull.Value ? string.Empty : dr["COUNTRY_NAME"].ToString().Trim();
    //                        //item.province_name = dr["PROVINCE_NAME"] == DBNull.Value ? string.Empty : dr["PROVINCE_NAME"].ToString().Trim();
    //                        //item.postal_code = dr["POSTAL_CODE"] == DBNull.Value ? string.Empty : dr["POSTAL_CODE"].ToString().Trim();
    //                        //item.suite_number = dr["SUITE_NUMNER"] == DBNull.Value ? string.Empty : dr["SUITE_NUMNER"].ToString().Trim();
    //                        item.company_code = dr["COMPANY_CODE"] == DBNull.Value ? string.Empty : dr["COMPANY_CODE"].ToString().Trim();
    //                        item.ahfs_name = dr["AHFS"] == DBNull.Value ? string.Empty : dr["AHFS"].ToString().Trim();
    //                        item.atc_name = dr["ATC"] == DBNull.Value ? string.Empty : dr["ATC"].ToString().Trim();
    //                        item.pm_name = dr["PM_NAME"] == DBNull.Value ? string.Empty : dr["PM_NAME"].ToString().Trim();
    //                        item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
    //                        item.drug_identification_number = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
    //                        item.history_date = dr["HISTORY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["HISTORY_DATE"]);
    //                        item.external_status_code = dr["EXTERNAL_STATUS_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["EXTERNAL_STATUS_CODE"]);
    //                        item.original_market_date = dr["ORIGINAL_MARKET_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ORIGINAL_MARKET_DATE"]);
    //                        item.form_name = dr["FORM_NAME"] == DBNull.Value ? string.Empty : dr["FORM_NAME"].ToString().Trim();
    //                        item.route_name = dr["ROUTE_NAME"] == DBNull.Value ? string.Empty : dr["ROUTE_NAME"].ToString().Trim();
    //                        Company company = new Company();
    //                        company = GetCompanyByCompanyCode(Int32.Parse(item.company_code), lang);
    //                        if (company != null)
    //                        {
    //                            item.company = company;
    //                        }
    //                        drugProduct = item;
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string errorMessages = string.Format("DbConnection.cs - GetDrugProductByDrugCode()");
    //            ExceptionHelper.LogException(ex, errorMessages);
    //            Console.WriteLine(errorMessages);
    //        }
    //        finally
    //        {
    //            if (con.State == ConnectionState.Open)
    //                con.Close();
    //        }
    //    }
    //    return drugProduct;
    //}
    // KEEP if we decide to do the search for DPD
    //public List<DrugProduct> GetAllDrugProduct(string lang)
    //{
    //    var orderClause = "";
    //    var items = new List<DrugProduct>();
    //    string commandText = "SELECT DISTINCT A.DRUG_CODE, A.DRUG_IDENTIFICATION_NUMBER, A.NUMBER_OF_AIS, A.AI_GROUP_NO,";
    //    commandText += " B.COMPANY_CODE, E.DOSAGE_VALUE, E.DOSAGE_UNIT, E.STRENGTH, ";
    //    if (lang.Equals("fr"))
    //    {
    //        commandText += " A.BRAND_NAME, A.BRAND_NAME_F, A.CLASS_F as CLASS,D.SCHEDULE_F as SCHEDULE, E.INGREDIENT_F as INGREDIENT,";
    //        commandText += " E.STRENGTH_UNIT_F as STRENGTH_UNIT, EX.EXTERNAL_STATUS_FRENCH as EXTERNAL_STATUS, pm.PM_FRENCH_FNAME as PM_NAME";
    //    }
    //    else {
    //        commandText += " A.BRAND_NAME, A.BRAND_NAME_F, A.CLASS, D.SCHEDULE, E.INGREDIENT, E.STRENGTH_UNIT, EX.EXTERNAL_STATUS_ENGLISH as EXTERNAL_STATUS, pm.PM_ENGLISH_FNAME as PM_NAME";
    //    }

    //    commandText += " FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT A";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_STATUS C on A.DRUG_CODE = C.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_STATUS_EXTERNAL EX on C.EXTERNAL_STATUS_CODE = EX.EXTERNAL_STATUS_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_SCHEDULE D on A.DRUG_CODE = D.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_FORM F on A.DRUG_CODE = F.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_ROUTE R on A.DRUG_CODE = R.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_AHFS H on A.DRUG_CODE = H.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_ATC T on A.DRUG_CODE = T.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_ACTIVE_INGREDIENTS E on A.DRUG_CODE = E.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_PM_DRUG pm ON A.DRUG_CODE = pm.DRUG_CODE";
    //    commandText += " WHERE E.id = (select min(id) from DPD_ONLINE_OWNER.wqry_active_ingredients E where A.drug_code = E.drug_code)";
    //    commandText += " ORDER BY" + orderClause + " A.DRUG_IDENTIFICATION_NUMBER";
    //    using (OracleConnection con = new OracleConnection(DpdDBConnection))
    //    {
    //        OracleCommand cmd = new OracleCommand(commandText, con);
    //        try
    //        {
    //            con.Open();
    //            using (OracleDataReader dr = cmd.ExecuteReader())
    //            {
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        var item = new DrugProduct();

    //                        if (lang.Equals("fr"))
    //                        {
    //                            item.brand_name = dr["BRAND_NAME_F"] == DBNull.Value ? dr["BRAND_NAME"].ToString().Trim() : dr["BRAND_NAME_F"].ToString().Trim();
    //                        }
    //                        else
    //                        {
    //                            item.brand_name = dr["BRAND_NAME"] == DBNull.Value ? dr["BRAND_NAME_F"].ToString().Trim() : dr["BRAND_NAME"].ToString().Trim();
    //                        }
    //                        item.class_name = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
    //                        item.status_name = dr["EXTERNAL_STATUS"] == DBNull.Value ? string.Empty : dr["EXTERNAL_STATUS"].ToString().Trim();
    //                        item.schedule_name = dr["SCHEDULE"] == DBNull.Value ? string.Empty : dr["SCHEDULE"].ToString().Trim();
    //                        item.ai_name = dr["INGREDIENT"] == DBNull.Value ? string.Empty : dr["INGREDIENT"].ToString().Trim();
    //                        item.strength = dr["STRENGTH"] == DBNull.Value ? string.Empty : dr["STRENGTH"].ToString().Trim();
    //                        item.strength_unit_name = dr["STRENGTH_UNIT"] == DBNull.Value ? string.Empty : dr["STRENGTH_UNIT"].ToString().Trim();
    //                        item.dosage_value = dr["DOSAGE_VALUE"] == DBNull.Value ? string.Empty : dr["DOSAGE_VALUE"].ToString().Trim();
    //                        item.dosage_unit = dr["DOSAGE_UNIT"] == DBNull.Value ? string.Empty : dr["DOSAGE_UNIT"].ToString().Trim();
    //                        item.ai_group_no = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
    //                        item.number_of_ais = dr["NUMBER_OF_AIS"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NUMBER_OF_AIS"]);
    //                        item.pm_name = dr["PM_NAME"] == DBNull.Value ? string.Empty : dr["PM_NAME"].ToString().Trim();
    //                        item.company_code = dr["COMPANY_CODE"] == DBNull.Value ? string.Empty : dr["COMPANY_CODE"].ToString().Trim();
    //                        item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
    //                        item.drug_identification_number = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
    //                        Company company = new Company();
    //                        company = GetCompanyByCompanyCode(Int32.Parse(item.company_code), lang);
    //                        if (company != null)
    //                        {
    //                            item.company = company;
    //                        }
    //                        items.Add(item);
    //                    }
    //                }
    //            }
    //        }

    //        catch (Exception ex)
    //        {
    //            string errorMessages = string.Format("DbConnection.cs - GetAllDrugProduct()");
    //            ExceptionHelper.LogException(ex, errorMessages);
    //            Console.WriteLine(errorMessages);
    //        }
    //        finally
    //        {
    //            if (con.State == ConnectionState.Open)
    //                con.Close();
    //        }
    //    }
    //    return items;
    //}
    /// KEEP if we decide to do the search for DPD
    //public List<DrugProduct> GetBySearchCriteria(string din, string brandname, string company, string lang)
    //{
    //    var orderClause = "";
    //    var items = new List<DrugProduct>();
    //    string commandText = "SELECT DISTINCT D.DRUG_CODE, D.DRUG_IDENTIFICATION_NUMBER, D.NUMBER_OF_AIS, D.AI_GROUP_NO,";
    //    commandText += " C.COMPANY_NAME, I.DOSAGE_VALUE, I.DOSAGE_UNIT, I.STRENGTH, ";
    //    if (lang.Equals("fr"))
    //    {
    //        commandText += " D.BRAND_NAME, D.BRAND_NAME_F, D.CLASS_F as CLASS, S.SCHEDULE_F as SCHEDULE, I.INGREDIENT_F as INGREDIENT,";
    //        commandText += " I.STRENGTH_UNIT_F as STRENGTH_UNIT, EX.EXTERNAL_STATUS_FRENCH as EXTERNAL_STATUS, PM.PM_FRENCH_FNAME as PM_NAME";
    //        commandText += ", CASE WHEN D.BRAND_NAME_F IS NOT NULL THEN UPPER(D.BRAND_NAME_F)";
    //        commandText += " WHEN D.BRAND_NAME IS NOT NULL THEN upper(D.BRAND_NAME)";
    //        commandText += " ELSE NULL END AS SORT_COLUMN";
    //    }
    //    else {
    //        commandText += " D.BRAND_NAME, D.BRAND_NAME_F, D.CLASS, S.SCHEDULE, I.INGREDIENT, I.STRENGTH_UNIT, EX.EXTERNAL_STATUS_ENGLISH as EXTERNAL_STATUS, PM.PM_ENGLISH_FNAME as PM_NAME";
    //        commandText += ", CASE WHEN D.BRAND_NAME IS NOT NULL THEN UPPER(D.BRAND_NAME)";
    //        commandText += " WHEN D.BRAND_NAME_F IS NOT NULL THEN upper(D.BRAND_NAME_F)";
    //        commandText += " ELSE NULL END AS SORT_COLUMN";
    //    }
    //    commandText += " FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT D";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_STATUS ST on D.DRUG_CODE = ST.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_STATUS_EXTERNAL EX on ST.EXTERNAL_STATUS_CODE = EX.EXTERNAL_STATUS_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_SCHEDULE S on D.DRUG_CODE = S.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_ACTIVE_INGREDIENTS I on D.DRUG_CODE = I.DRUG_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_COMPANIES C ON D.COMPANY_CODE = C.COMPANY_CODE";
    //    commandText += " LEFT OUTER JOIN DPD_ONLINE_OWNER.WQRY_PM_DRUG PM ON D.DRUG_CODE = PM.DRUG_CODE";
    //    commandText += " WHERE";
    //    commandText += " I.id = (select min(id) from DPD_ONLINE_OWNER.wqry_active_ingredients I where D.drug_code = I.drug_code) AND ";
    //    commandText += " (";
    //    if (din != null)
    //    {
    //        commandText += " UPPER(D.DRUG_IDENTIFICATION_NUMBER) LIKE '%" + din.ToUpper() + "%'";
    //    }
    //    if (brandname != null)
    //    {
    //        if (din != null) commandText += " OR";

    //        commandText += " UPPER(D.BRAND_NAME_F) LIKE '%" + brandname.ToUpper() + "%'";
    //        commandText += " OR UPPER(D.BRAND_NAME) LIKE '%" + brandname.ToUpper() + "%'";
    //    }
    //    if (company != null)
    //    {
    //        if ((din != null) || (brandname != null)) commandText += " OR";
    //        commandText += " UPPER(C.COMPANY_NAME) LIKE '%" + company.ToUpper() + "%'";
    //    }
    //    commandText += ")";


    //    if (lang.Equals("fr"))
    //    {
    //        orderClause += " translate(C.COMPANY_NAME,'ÀÂÄÇÈÉËÊÌÎÏÒÔÖÙÚÛÜ','AAACEEEEIIIOOOUUUU'), translate(D.BRAND_NAME_F,'ÀÂÄÇÈÉËÊÌÎÏÒÔÖÙÚÛÜ','AAACEEEEIIIOOOUUUU'),";
    //    }
    //    else
    //    {
    //        orderClause += " translate(C.COMPANY_NAME,'ÀÂÄÇÈÉËÊÌÎÏÒÔÖÙÚÛÜ','AAACEEEEIIIOOOUUUU'), translate(D.BRAND_NAME,'ÀÂÄÇÈÉËÊÌÎÏÒÔÖÙÚÛÜ','AAACEEEEIIIOOOUUUU'),";
    //    }


    //    using (OracleConnection con = new OracleConnection(DpdDBConnection))
    //    {
    //        OracleCommand cmd = new OracleCommand(commandText, con);
    //        try
    //        {
    //            con.Open();
    //            using (OracleDataReader dr = cmd.ExecuteReader())
    //            {
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        var item = new DrugProduct();
    //                        if (lang.Equals("fr"))
    //                        {
    //                            item.brand_name = dr["BRAND_NAME_F"] == DBNull.Value ? dr["BRAND_NAME"].ToString().Trim() : dr["BRAND_NAME_F"].ToString().Trim();
    //                        }
    //                        else
    //                        {
    //                            item.brand_name = dr["BRAND_NAME"] == DBNull.Value ? dr["BRAND_NAME_F"].ToString().Trim() : dr["BRAND_NAME"].ToString().Trim();
    //                        }
    //                        item.class_name = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
    //                        item.status_name = dr["EXTERNAL_STATUS"] == DBNull.Value ? string.Empty : dr["EXTERNAL_STATUS"].ToString().Trim();
    //                        item.schedule_name = dr["SCHEDULE"] == DBNull.Value ? string.Empty : dr["SCHEDULE"].ToString().Trim();
    //                        item.ai_name = dr["INGREDIENT"] == DBNull.Value ? string.Empty : dr["INGREDIENT"].ToString().Trim();
    //                        item.strength = dr["STRENGTH"] == DBNull.Value ? string.Empty : dr["STRENGTH"].ToString().Trim();
    //                        item.strength_unit_name = dr["STRENGTH_UNIT"] == DBNull.Value ? string.Empty : dr["STRENGTH_UNIT"].ToString().Trim();
    //                        item.dosage_value = dr["DOSAGE_VALUE"] == DBNull.Value ? string.Empty : dr["DOSAGE_VALUE"].ToString().Trim();
    //                        item.dosage_unit = dr["DOSAGE_UNIT"] == DBNull.Value ? string.Empty : dr["DOSAGE_UNIT"].ToString().Trim();
    //                        item.ai_group_no = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
    //                        item.number_of_ais = dr["NUMBER_OF_AIS"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NUMBER_OF_AIS"]);
    //                        item.pm_name = dr["PM_NAME"] == DBNull.Value ? string.Empty : dr["PM_NAME"].ToString().Trim();
    //                        //item.company_name = dr["COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["COMPANY_NAME"].ToString().Trim();
    //                        item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
    //                        item.drug_identification_number = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();

    //                        items.Add(item);
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string errorMessages = string.Format("DbConnection.cs - GetBySearchCriteria()");
    //            ExceptionHelper.LogException(ex, errorMessages);
    //            Console.WriteLine(errorMessages);
    //        }
    //        finally
    //        {
    //            if (con.State == ConnectionState.Open)
    //                con.Close();
    //        }
    //    }
    //    return items;
    //}

}
