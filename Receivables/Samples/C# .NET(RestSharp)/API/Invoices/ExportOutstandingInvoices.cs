/// <summary>
/// API Request to get outstanding invoices exported to a csv
/// </summary>
/// <param name="URL">URL of the PayFabric Receivables site</param>
/// <param name="token">PayFabric Receivables token object</param>
/// <param name="invoices">Returned invoice object</param>
public void GetOutstandingInvoices(string URL, Token token, ref CSVResponse invoices)
{
	// Sample request and response
	// ------------------------------------------------------
	// Go to https://github.com/PayFabric/APIs/blob/master/Receivables/Sections/APIs/API/Invoices.md#export-outstanding-invoices for more details about request and response.
	// ------------------------------------------------------
	
	var client = new RestClient(URL + "API/invoices/outstanding/export?filter.criteria.CustomerId=Nodus0001");
	var request = new RestRequest(Method.POST);
	request.AddHeader("content-type", "application/json");
	request.AddHeader("authorization", "Bearer " + token.access_token);
	IRestResponse response = client.Execute(request);

	if (response.StatusCode == System.Net.HttpStatusCode.OK)
	{
		try
		{
			invoices = ConverToCSV(response);
		}
		catch
		{
			invoices = null;
		}
	}
	else
		invoices = null;
}
