using System;
using VDS.RDF.Query;

// Клієнт для виконання SPARQL запитів
public class SparqlClient
{
    private readonly string _endpointUrl;

    public SparqlClient(string endpointUrl)
    {
        _endpointUrl = endpointUrl;
    }
    
    // Виконання SPARQL запиту
    public SparqlResultSet ExecuteQuery(string query)
    {
        var endpoint = new SparqlRemoteEndpoint(new Uri(_endpointUrl));
        return endpoint.QueryWithResultSet(query);
    }
}