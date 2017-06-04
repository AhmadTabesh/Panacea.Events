using Newtonsoft.Json;
using Panacea.Events.DataObjects;
using Panacea.Events.DataObjects.DTO;
using Panacea.Events.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Panacea.Events.Web
{
    public partial class _Default : Page
    {
        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Bind available events list on page load
                BindEvents();
            }
        }

        #endregion

        #region Events Loading

        /// <summary>
        /// Retreive available events list and bind them into a dropdown list
        /// </summary>
        private void BindEvents()
        {
            try
            {
                //Send a get request to the restful webservice
                string response = ServiceManager.DoGetRequest("GetEvents");

                if (!string.IsNullOrEmpty(response))
                {
                    //Check if the response is an error response
                    ErrorResponse errorResponse = new ErrorResponse();
                    errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    if (errorResponse != null && !string.IsNullOrEmpty(errorResponse.ErrorCode))
                    {
                        ErrorMessage.Text = Constants.EventsLoadingError;
                    }
                    else
                    {
                        //Response contains no error, deserialize the result and bind data to the dropdown list
                        GetEventsResponse result = new GetEventsResponse();
                        result = JsonConvert.DeserializeObject<GetEventsResponse>(response);
                        if (result != null && result.Data != null)
                        {
                            ddlEvents.DataSource = result.Data;
                            ddlEvents.DataValueField = "Id";
                            ddlEvents.DataTextField = "Name";
                            ddlEvents.DataBind();

                            ddlEvents.Items.Insert(0, new ListItem("<Choose Event>", ""));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = Constants.EventsLoadingError;

            }

        }

        #endregion

        #region Registration Submission

        protected void Register_Click(object sender, EventArgs e)
        {
            try
            {
                //Remove messages displayed in the page if any.
                ErrorMessage.Text = "";
                SuccessMessage.Text = "";

                //Fill the data transfer object parameters from form fields
                AddParticipantDTO objParticipant = new AddParticipantDTO();
                objParticipant.Email = txtEmail.Text;
                objParticipant.FirstName = txtFirstName.Text;

                string[] dateFormats = { "dd/MM/yyyy HH:mm" };

                DateTime arrivalDate = new DateTime();
                if (!string.IsNullOrEmpty(txtArrivalDate.Text))
                {
                    DateTime dateValue;
                    if (DateTime.TryParseExact(txtArrivalDate.Text, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                        arrivalDate = dateValue;
                    else
                    {
                        ErrorMessage.Text = Constants.ArrivalDateError;
                    }
                }

                objParticipant.ArrivalDate = arrivalDate;
                objParticipant.RegistrationDate = DateTime.Now;
                objParticipant.Country = ddlCountries.SelectedValue;
                objParticipant.EventId = int.Parse(ddlEvents.SelectedValue);

                string jsonData = new JavaScriptSerializer().Serialize(objParticipant);

                //Send a post requst to the restful webservice
                string response = ServiceManager.DoPostRequest("AddParticipant", jsonData);
                if (!string.IsNullOrEmpty(response))
                {
                    //Check if the response is an error response
                    ErrorResponse errorResponse = new ErrorResponse();
                    errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    if (errorResponse != null && !string.IsNullOrEmpty(errorResponse.ErrorCode))
                    {
                        if (errorResponse.ErrorCode == "ParticipantExists")
                            ErrorMessage.Text = errorResponse.ErrorDescription;
                        else
                            ErrorMessage.Text = Constants.DefaultError;
                    }
                    else
                    {
                        //Response contains no error, display a success message.
                        SuccessMessage.Text = Constants.SuccessfulRegistration;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = Constants.DefaultError;
            }
        }

        #endregion


    }
}