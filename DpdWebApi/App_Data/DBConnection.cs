using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using DpdWebApi.Models;
using System.Data.Odbc;
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

        public List<Form> GetAllForm()
        {
            var items = new List<Form>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_FORM";

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
                                var item = new Form();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.PharmFormCode = dr["PHARM_FORM_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PHARM_FORM_CODE"]);
                                item.PharmaceuticalForm = dr["PHARMACEUTICAL_FORM"] == DBNull.Value ? string.Empty : dr["PHARMACEUTICAL_FORM"].ToString().Trim();
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

        public Form GetFormByDrugCode(int id)
        {
            var form = new Form();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_FORM WHERE DRUG_CODE = " + id;

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
                                var item = new Form();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.PharmFormCode = dr["PHARM_FORM_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PHARM_FORM_CODE"]);
                                item.PharmaceuticalForm = dr["PHARMACEUTICAL_FORM"] == DBNull.Value ? string.Empty : dr["PHARMACEUTICAL_FORM"].ToString().Trim();

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

        public List<Packaging> GetAllPackaging()
        {
            var items = new List<Packaging>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_PACKAGING";

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
                                var item = new Packaging();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.Upc = dr["UPC"] == DBNull.Value ? string.Empty : dr["UPC"].ToString().Trim();
                                item.PackageSizeUnit = dr["PACKAGE_SIZE_UNIT"] == DBNull.Value ? string.Empty : dr["PACKAGE_SIZE_UNIT"].ToString().Trim();
                                item.PackageType = dr["PACKAGE_TYPE"] == DBNull.Value ? string.Empty : dr["PACKAGE_TYPE"].ToString().Trim();
                                item.PackageSize = dr["PACKAGE_SIZE"] == DBNull.Value ? string.Empty : dr["PACKAGE_SIZE"].ToString().Trim();
                                item.ProductInformation = dr["PRODUCT_INFORMATION"] == DBNull.Value ? string.Empty : dr["PRODUCT_INFORMATION"].ToString().Trim();
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

        public Packaging GetPackagingByDrugCode(int id)
        {
            var packaging = new Packaging();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_PACKAGING WHERE DRUG_CODE = " + id;

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
                                var item = new Packaging();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.Upc = dr["UPC"] == DBNull.Value ? string.Empty : dr["UPC"].ToString().Trim();
                                item.PackageSizeUnit = dr["PACKAGE_SIZE_UNIT"] == DBNull.Value ? string.Empty : dr["PACKAGE_SIZE_UNIT"].ToString().Trim();
                                item.PackageType = dr["PACKAGE_TYPE"] == DBNull.Value ? string.Empty : dr["PACKAGE_TYPE"].ToString().Trim();
                                item.PackageSize = dr["PACKAGE_SIZE"] == DBNull.Value ? string.Empty : dr["PACKAGE_SIZE"].ToString().Trim();
                                item.ProductInformation = dr["PRODUCT_INFORMATION"] == DBNull.Value ? string.Empty : dr["PRODUCT_INFORMATION"].ToString().Trim();

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
                                var item = new PharmaceuticalStd();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.PharmaceuticalStd = dr["PHARMACEUTICAL_STD"] == DBNull.Value ? string.Empty : dr["PHARMACEUTICAL_STD"].ToString().Trim();
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllPharamceuticalStd()");
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
            var pharmaceuticalStd = new PharmaceuticalStd();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_PHARMACEUTICAL_STD WHERE DRUG_CODE = " + id;

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
                                var item = new PharmaceuticalStd();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                
                                pharmaceuticalStd = item;
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
            return pharmaceuticalStd;
        }

        public List<Schedule> GetAllSchedule()
        {
            var items = new List<Schedule>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_SCHEDULE";

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
                                var item = new Schedule();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.Schedule = dr["SCHEDULE"] == DBNull.Value ? string.Empty : dr["SCHEDULE"].ToString().Trim();
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

        public Schedule GetScheduleByDrugCode(int id)
        {
            var schedule = new Schedule();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_SCHEDULE WHERE DRUG_CODE = " + id;

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
                                var item = new Schedule();
                                item.Schedule = dr["SCHEDULE"] == DBNull.Value ? string.Empty : dr["SCHEDULE"].ToString().Trim();

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

        public List<TherapeuticClass> GetAllTherapeuticClass()
        {
            var items = new List<TherapeuticClass>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_THERAPEUTIC_CLASS";

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
                                var item = new TherapeuticClass();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.TcAtcNumber = dr["TC_ATC_NUMBER"] == DBNull.Value ? string.Empty : dr["TC_ATC_NUMBER"].ToString().Trim();
                                item.TcAtc = dr["TC_ATC"] == DBNull.Value ? string.Empty : dr["TC_ATC"].ToString().Trim();
                                item.TcAhfsNumber = dr["TC_AHFS_NUMBER"] == DBNull.Value ? string.Empty : dr["TC_AHFS_NUMBER"].ToString().Trim();
                                item.TcAhfs = dr["TC_AHFS"] == DBNull.Value ? string.Empty : dr["TC_AHFS"].ToString().Trim();

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

        public TherapeuticClass GetTherapeuticClassByDrugCode(int id)
        {
            var therapeuticClass = new TherapeuticClass();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_THERAPEUTIC_CLASS WHERE DRUG_CODE = " + id;

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
                                var item = new TherapeuticClass();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.TcAtcNumber = dr["TC_ATC_NUMBER"] == DBNull.Value ? string.Empty : dr["TC_ATC_NUMBER"].ToString().Trim();
                                item.TcAtc = dr["TC_ATC"] == DBNull.Value ? string.Empty : dr["TC_ATC"].ToString().Trim();
                                item.TcAhfsNumber = dr["TC_AHFS_NUMBER"] == DBNull.Value ? string.Empty : dr["TC_AHFS_NUMBER"].ToString().Trim();
                                item.TcAhfs = dr["TC_AHFS"] == DBNull.Value ? string.Empty : dr["TC_AHFS"].ToString().Trim();

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

        public List<VeterinarySpecies> GetAllVeterinarySpecies()
        {
            var items = new List<TherapeuticClass>();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_VETERINARY_SPECIES";

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
                                var item = new VeterinarySpecies();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.VetSpecies = dr["VET_SPECIES"] == DBNull.Value ? string.Empty : dr["VET_SPECIES"].ToString().Trim();
                                item.VetSubSpecies = dr["VET_SUB_SPECIES"] == DBNull.Value ? string.Empty : dr["VET_SUB_SPECIES"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllVeterinarySpecies()");
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

        public VeterinarySpecies GetVeterinarySpeciesByDrugCode(int id)
        {
            var veterinarySpecies = new VeterinarySpecies();
            string commandText = "SELECT * FROM DPD_ONLINE_OWNER.WQRY_VETERINARY_SPECIES WHERE DRUG_CODE = " + id;

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
                                var item = new VeterinarySpecies();
                                item.DrugCode = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
                                item.VetSpecies = dr["VET_SPECIES"] == DBNull.Value ? string.Empty : dr["VET_SPECIES"].ToString().Trim();
                                item.VetSubSpecies = dr["VET_SUB_SPECIES"] == DBNull.Value ? string.Empty : dr["VET_SUB_SPECIES"].ToString().Trim();

                                veterinarySpecies = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetVeterinarySpeciesByDrugCode()");
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

}
