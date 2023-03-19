namespace FCA_Res_Api;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        //Endpoint Mapping
        app.MapGet("/GetAuthStatus/{urn}", GetAuthStatus);
        app.MapGet("/PostCodeFCALookup/{postcode}", PostCodeFCALookup);
    }

    private static async Task<IResult> GetAuthStatus(int urn, Ifirmsmastdata data)
    {
        try
        {
            var results = await data.GetAuthStatus(urn);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);

        }

    }

  
            private static async Task<IResult> PostCodeFCALookup(string postcode, Ifirmsmastdata data)
        {
            try
            {
                var results = await data.PostCodeFCALookup(postcode);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }


    }



