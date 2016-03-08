using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using DpdWebApi.Models;
using Oracle.ManagedDataAccess.Client;
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


        public List<DrugProduct> GetAllDrugProduct()
        {
            var items = new List<DrugProduct>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                                var item  = new DrugProduct();
                                item.AiGroupNo = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
                                item.BrandNameE = dr["BRAND_NAME"] == DBNull.Value ? string.Empty : dr["BRAND_NAME"].ToString().Trim();
                                item.BrandNameF = dr["BRAND_NAME_F"] == DBNull.Value ? string.Empty : dr["BRAND_NAME_F"].ToString().Trim();
                                item.ClassE = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
                                item.ClassF = dr["CLASS_F"] == DBNull.Value ? string.Empty : dr["CLASS_F"].ToString().Trim();
                                item.CompanyCode = dr["COMPANY_CODE"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["COMPANY_CODE"]);
                                item.DescriptorE = dr["DESCRIPTOR"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR"].ToString().Trim();
                                item.DescriptorF = dr["DESCRIPTOR_F"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR_F"].ToString().Trim();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["DRUG_CODE"]);
                                item.DrugIdentificationNumber  = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
                                item.NumberOfAis = dr["NUMBER_OF_AIS"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["NUMBER_OF_AIS"]);

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllInspections()");
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

        public DrugProduct GetDrugProductByDrugCode(int id)
        {
            var drugProduct = new DrugProduct();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT WHERE DRUG_CODE = " + id;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                             var item  = new DrugProduct();
                                item.AiGroupNo = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
                                item.BrandNameE = dr["BRAND_NAME"] == DBNull.Value ? string.Empty : dr["BRAND_NAME"].ToString().Trim();
                                item.BrandNameF = dr["BRAND_NAME_F"] == DBNull.Value ? string.Empty : dr["BRAND_NAME_F"].ToString().Trim();
                                item.ClassE = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
                                item.ClassF = dr["CLASS_F"] == DBNull.Value ? string.Empty : dr["CLASS_F"].ToString().Trim();
                                item.CompanyCode = dr["COMPANY_CODE"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["COMPANY_CODE"]);
                                item.DescriptorE = dr["DESCRIPTOR"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR"].ToString().Trim();
                                item.DescriptorF = dr["DESCRIPTOR_F"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR_F"].ToString().Trim();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["DRUG_CODE"]);
                                item.DrugIdentificationNumber  = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
                                item.NumberOfAis = dr["NUMBER_OF_AIS"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["NUMBER_OF_AIS"]);

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

        public DrugProduct GetDrugProductByDin(String din)
        {
            var drugProduct = new DrugProduct();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT WHERE DRUG_IDENTIFICATION_NUMBER = " + din;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                                var item = new DrugProduct();
                                item.AiGroupNo = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
                                item.BrandNameE = dr["BRAND_NAME"] == DBNull.Value ? string.Empty : dr["BRAND_NAME"].ToString().Trim();
                                item.BrandNameF = dr["BRAND_NAME_F"] == DBNull.Value ? string.Empty : dr["BRAND_NAME_F"].ToString().Trim();
                                item.ClassE = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
                                item.ClassF = dr["CLASS_F"] == DBNull.Value ? string.Empty : dr["CLASS_F"].ToString().Trim();
                                item.CompanyCode = dr["COMPANY_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["COMPANY_CODE"]);
                                item.DescriptorE = dr["DESCRIPTOR"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR"].ToString().Trim();
                                item.DescriptorF = dr["DESCRIPTOR_F"] == DBNull.Value ? string.Empty : dr["DESCRIPTOR_F"].ToString().Trim();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.DrugIdentificationNumber = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
                                item.NumberOfAis = dr["NUMBER_OF_AIS"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUMBER_OF_AIS"]);

                                drugProduct = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetDrugProductByDin()");
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

        public List<ActiveIngredient> GetAllActiveIngredient()
        {
            var items = new List<ActiveIngredient>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ACTIVE_INGREDIENTS";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                                item.ActiveIngredientId = dr["ID"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["ID"]);
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["DRUG_CODE"]);
                                item.ActiveIngredientCode = dr["ACTIVE_INGREDIENT_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ACTIVE_INGREDIENT_CODE"]);
                                item.IngredientNameE = dr["INGREDIENT"] == DBNull.Value ? string.Empty : dr["INGREDIENT"].ToString().Trim();
                                item.IngredientNameF = dr["INGREDIENT_F"] == DBNull.Value ? string.Empty : dr["INGREDIENT_F"].ToString().Trim();
                                item.Strength = dr["STRENGTH"] == DBNull.Value ? string.Empty : dr["STRENGTH"].ToString().Trim();
                                item.StrengthUnitE = dr["STRENGTH_UNIT"] == DBNull.Value ? string.Empty : dr["STRENGTH_UNIT"].ToString().Trim();
                                item.StrengthUnitF = dr["STRENGTH_UNIT_F"] == DBNull.Value ? string.Empty : dr["STRENGTH_UNIT_F"].ToString().Trim();
                                item.DosageValue = dr["DOSAGE_VALUE"] == DBNull.Value ? string.Empty : dr["DOSAGE_VALUE"].ToString().Trim();
                                item.DosageUnitE = dr["DOSAGE_UNIT"] == DBNull.Value ? string.Empty : dr["DOSAGE_UNIT"].ToString().Trim();
                                item.DosageUnitF = dr["DOSAGE_UNIT_F"] == DBNull.Value ? string.Empty : dr["DOSAGE_UNIT_F"].ToString().Trim();
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

        public ActiveIngredient GetActiveIngredientById(int id)
        {
            var activeIngredient = new ActiveIngredient();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ACTIVE_INGREDIENTS WHERE ID = " + id;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                             var item  = new ActiveIngredient();
                             item.ActiveIngredientId = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"]);
                             item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                             item.ActiveIngredientCode = dr["ACTIVE_INGREDIENT_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ACTIVE_INGREDIENT_CODE"]);
                             item.IngredientNameE = dr["INGREDIENT"] == DBNull.Value ? string.Empty : dr["INGREDIENT"].ToString().Trim();
                             item.IngredientNameF = dr["INGREDIENT_F"] == DBNull.Value ? string.Empty : dr["INGREDIENT_F"].ToString().Trim();
                             item.Strength = dr["STRENGTH"] == DBNull.Value ? string.Empty : dr["STRENGTH"].ToString().Trim();
                             item.StrengthUnitE = dr["STRENGTH_UNIT"] == DBNull.Value ? string.Empty : dr["STRENGTH_UNIT"].ToString().Trim();
                             item.StrengthUnitF = dr["STRENGTH_UNIT_F"] == DBNull.Value ? string.Empty : dr["STRENGTH_UNIT_F"].ToString().Trim();
                             item.DosageValue = dr["DOSAGE_VALUE"] == DBNull.Value ? string.Empty : dr["DOSAGE_VALUE"].ToString().Trim();
                             item.DosageUnitE = dr["DOSAGE_UNIT"] == DBNull.Value ? string.Empty : dr["DOSAGE_UNIT"].ToString().Trim();
                             item.DosageUnitF = dr["DOSAGE_UNIT_F"] == DBNull.Value ? string.Empty : dr["DOSAGE_UNIT_F"].ToString().Trim();
                               
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
    
        public List<Company> GetAllCompany()
        {
            var items = new List<Company>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_COMPANIES";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                                item.CompanyCode = dr["COMPANY_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["COMPANY_CODE"]);
                                item.MfrCode = dr["MFR_CODE"] == DBNull.Value ? string.Empty : dr["MFR_CODE"].ToString().Trim();
                                item.CompanyName = dr["COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["COMPANY_NAME"].ToString().Trim();
                                item.CompanyType = dr["COMPANY_TYPE"] == DBNull.Value ? string.Empty : dr["COMPANY_TYPE"].ToString().Trim();
                                item.SuiteNumber = dr["SUITE_NUMNER"] == DBNull.Value ? string.Empty : dr["SUITE_NUMNER"].ToString().Trim();
                                item.StreetNameE = dr["STREET_NAME"] == DBNull.Value ? string.Empty : dr["STREET_NAME"].ToString().Trim();
                                item.StreetNameF = dr["STREET_NAME_F"] == DBNull.Value ? string.Empty : dr["STREET_NAME_F"].ToString().Trim();
                                item.CityName = dr["CITY_NAME"] == DBNull.Value ? string.Empty : dr["CITY_NAME"].ToString().Trim();
                                item.ProvinceE = dr["PROVINCE"] == DBNull.Value ? string.Empty : dr["PROVINCE"].ToString().Trim();
                                item.ProvinceF = dr["PROVINCE_F"] == DBNull.Value ? string.Empty : dr["PROVINCE_F"].ToString().Trim();
                                item.CountryE = dr["COUNTRY"] == DBNull.Value ? string.Empty : dr["COUNTRY"].ToString().Trim();
                                item.CountryF = dr["COUNTRY_F"] == DBNull.Value ? string.Empty : dr["COUNTRY_F"].ToString().Trim();
                                item.PostalCode = dr["POSTAL_CODE"] == DBNull.Value ? string.Empty : dr["POSTAL_CODE"].ToString().Trim();
                                item.PostOfficeBox = dr["POST_OFFICE_BOX"] == DBNull.Value ? string.Empty : dr["POST_OFFICE_BOX"].ToString().Trim();

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

        public Company GetCompanyByCompanyCode(int id)
        {
            var company = new Company();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_COMPANIES WHERE COMPANY_CODE = " + id;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                             item.CompanyCode = dr["COMPANY_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["COMPANY_CODE"]);
                             item.MfrCode = dr["MFR_CODE"] == DBNull.Value ? string.Empty : dr["MFR_CODE"].ToString().Trim();
                             item.CompanyName = dr["COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["COMPANY_NAME"].ToString().Trim();
                             item.CompanyType = dr["COMPANY_TYPE"] == DBNull.Value ? string.Empty : dr["COMPANY_TYPE"].ToString().Trim();
                             item.SuiteNumber = dr["SUITE_NUMNER"] == DBNull.Value ? string.Empty : dr["SUITE_NUMNER"].ToString().Trim();
                             item.StreetNameE = dr["STREET_NAME"] == DBNull.Value ? string.Empty : dr["STREET_NAME"].ToString().Trim();
                             item.StreetNameF = dr["STREET_NAME_F"] == DBNull.Value ? string.Empty : dr["STREET_NAME_F"].ToString().Trim();
                             item.CityName = dr["CITY_NAME"] == DBNull.Value ? string.Empty : dr["CITY_NAME"].ToString().Trim();
                             item.ProvinceE = dr["PROVINCE"] == DBNull.Value ? string.Empty : dr["PROVINCE"].ToString().Trim();
                             item.ProvinceF = dr["PROVINCE_F"] == DBNull.Value ? string.Empty : dr["PROVINCE_F"].ToString().Trim();
                             item.CountryE = dr["COUNTRY"] == DBNull.Value ? string.Empty : dr["COUNTRY"].ToString().Trim();
                             item.CountryF = dr["COUNTRY_F"] == DBNull.Value ? string.Empty : dr["COUNTRY_F"].ToString().Trim();
                             item.PostalCode = dr["POSTAL_CODE"] == DBNull.Value ? string.Empty : dr["POSTAL_CODE"].ToString().Trim();
                             item.PostOfficeBox = dr["POST_OFFICE_BOX"] == DBNull.Value ? string.Empty : dr["POST_OFFICE_BOX"].ToString().Trim();

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
        
        public List<Route> GetAllRoute()
        {
            var items = new List<Route>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ROUTE";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.RouteOfAdministrationCode = dr["ROUTE_OF_ADMINISTRATION_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ROUTE_OF_ADMINISTRATION_CODE"]);
                                item.RouteOfAdministrationE = dr["ROUTE_OF_ADMINISTRATION"] == DBNull.Value ? string.Empty : dr["ROUTE_OF_ADMINISTRATION"].ToString().Trim();
                                item.RouteOfAdministrationF = dr["ROUTE_OF_ADMINISTRATION_F"] == DBNull.Value ? string.Empty : dr["ROUTE_OF_ADMINISTRATION_F"].ToString().Trim();
                                item.InactiveDate = dr["INACTIVE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["INACTIVE_DATE"]);
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

        public Route GetRouteByDrugCode(int id)
        {
            var route = new Route();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_ROUTE WHERE DRUG_CODE = " + id;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.RouteOfAdministrationCode = dr["ROUTE_OF_ADMINISTRATION_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ROUTE_OF_ADMINISTRATION_CODE"]);
                                item.RouteOfAdministrationE = dr["ROUTE_OF_ADMINISTRATION"] == DBNull.Value ? string.Empty : dr["ROUTE_OF_ADMINISTRATION"].ToString().Trim();
                                item.RouteOfAdministrationF = dr["ROUTE_OF_ADMINISTRATION_F"] == DBNull.Value ? string.Empty : dr["ROUTE_OF_ADMINISTRATION_F"].ToString().Trim();
                                item.InactiveDate = dr["INACTIVE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["INACTIVE_DATE"]);
                               
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

        public List<Status> GetAllStatus()
        {
            var items = new List<Status>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_STATUS";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.StatusCode = dr["STATUS_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["STATUS_CODE"]);
                                item.StatusE = dr["STATUS"] == DBNull.Value ? string.Empty : dr["STATUS"].ToString().Trim();
                                item.StatusF = dr["STATUS_F"] == DBNull.Value ? string.Empty : dr["STATUS_F"].ToString().Trim();
                                item.HistoryDate = dr["HISTORY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["HISTORY_DATE"]);
                                item.FirstMarketedDate = dr["FIRST_MARKETED_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FIRST_MARKETED_DATE"]);
                                item.ExternalStatusCode = dr["EXTERNAL_STATUS_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["EXTERNAL_STATUS_CODE"]);
                                item.OriginalMarketDate = dr["ORIGINAL_MARKET_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ORIGINAL_MARKET_DATE"]);
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

        public Status GetStatusByDrugCode(int id)
        {
            var status = new Status();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_STATUS WHERE DRUG_CODE = " + id;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
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
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.StatusCode = dr["STATUS_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["STATUS_CODE"]);
                                item.StatusE = dr["STATUS"] == DBNull.Value ? string.Empty : dr["STATUS"].ToString().Trim();
                                item.StatusF = dr["STATUS_F"] == DBNull.Value ? string.Empty : dr["STATUS_F"].ToString().Trim();
                                item.HistoryDate = dr["HISTORY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["HISTORY_DATE"]);
                                item.FirstMarketedDate = dr["FIRST_MARKETED_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FIRST_MARKETED_DATE"]);
                                item.ExternalStatusCode = dr["EXTERNAL_STATUS_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["EXTERNAL_STATUS_CODE"]);
                                item.OriginalMarketDate = dr["ORIGINAL_MARKET_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ORIGINAL_MARKET_DATE"]);
                               
                                status = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetStatisByDrugCode()");
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
    }

}
