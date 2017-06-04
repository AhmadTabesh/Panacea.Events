using Newtonsoft.Json;
using Panacea.Events.DataObjects;
using Panacea.Events.DataObjects.DTO;
using Panacea.Events.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Panacea.Events.Web
{
    public partial class EventParticipants : System.Web.UI.Page
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

        #region Events dropdown events

        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Retreive the related participants and display in a gridview upon selecting an event.
            BindParticipantsGrid();
        }

        #endregion


        #region Participants Grid Events

        /// <summary>
        /// Retreive the related participants and display in a gridview upon selecting an event.
        /// </summary>
        private void BindParticipantsGrid()
        {
            try
            {
                //Fill the data transfer object fields
                GetParticipantsByEventDTO dto = new GetParticipantsByEventDTO();
                dto.EventId = int.Parse(ddlEvents.SelectedValue);
                if (ViewState["SortExpression"] != null)
                    dto.SortExpression = ViewState["SortExpression"].ToString();
                if (ViewState["SortDirection"] != null)
                    dto.SortDirection = ViewState["SortDirection"].ToString();

                string jsonData = new JavaScriptSerializer().Serialize(dto);

                //Send a post request to the restful webservice
                string response = ServiceManager.DoPostRequest("GetParticipantsByEvent", jsonData);
                if (!string.IsNullOrEmpty(response))
                {
                    //Check if the response is an error response
                    ErrorResponse errorResponse = new ErrorResponse();
                    errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    if (errorResponse != null && !string.IsNullOrEmpty(errorResponse.ErrorCode))
                    {
                        ErrorMessage.Text = Constants.DefaultError;
                    }
                    else
                    {
                        //Response contains no error, deserialize the result and bind data to the gridview
                        GetParticipantsByEventResponse result = new GetParticipantsByEventResponse();
                        result = JsonConvert.DeserializeObject<GetParticipantsByEventResponse>(response);
                        if (result != null && result.Data != null)
                        {
                            gvParticipants.DataSource = result.Data;
                            gvParticipants.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = Constants.DefaultError;
            }
        }

        protected void gvParticipants_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression && ViewState["SortDirection"].ToString() == SortDirection.Ascending.ToString())
            {
                sortDirection = SortDirection.Descending;
            }
            else
            {
                sortDirection = e.SortDirection;
            }

            ViewState["SortExpression"] = e.SortExpression;
            ViewState["SortDirection"] = sortDirection;

            BindParticipantsGrid();
        }

        #endregion

    }
}