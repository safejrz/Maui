namespace ShopApp.Services;

public class DatabaseRutaService : IDatabaseRutaService
{
    public string Get(string nombreArchivo)
    {
        var rutaDirectorio = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        return Path.Combine(rutaDirectorio, nombreArchivo);
    }
}
