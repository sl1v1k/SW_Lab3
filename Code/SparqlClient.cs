using System;
using VDS.RDF.Query;

/// <summary>
/// Клієнт для виконання SPARQL-запитів.
/// </summary>
public class SparqlClient
{
    private readonly string _endpointUrl;

    public SparqlClient(string endpointUrl)
    {
        _endpointUrl = endpointUrl;
    }

    /// <summary>
    /// Виконує SPARQL-запит і повертає результати.
    /// </summary>
    /// <param name="query">SPARQL-запит.</param>
    /// <returns>Результати запиту.</returns>
    public SparqlResultSet ExecuteQuery(string query)
    {
        SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri(_endpointUrl));
        return endpoint.QueryWithResultSet(query);
    }
}