using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using JetBrains.Annotations;
using System.Threading.Tasks;

public class DBMongo : MonoBehaviour
{
    private static MongoClient _client;
    private IMongoDatabase _database;
    private static IMongoCollection<ModelPlayer> _collection;
    public static DBMongo DBMongoInstance;
    private string iIdPlayer = "";

    private void Awake()
    {
        if (DBMongoInstance == null)
        {
            DBMongoInstance = this;
            DontDestroyOnLoad(DBMongoInstance);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            _client = new MongoClient("mongodb+srv://Jorge:Jorge01@cluster0.tbdkk.mongodb.net/?retryWrites=true&w=majority");
            _database = _client.GetDatabase("RampageInDolores");
            _collection = _database.GetCollection<ModelPlayer>("Player");
            if (_collection == null)
            {
                Debug.LogError("Error al obtener la colección de la base de datos.");
            }
            else
            {
                Debug.Log("Exito");
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("ERROR DBMongo: " + e.Message);
            _client = null;
        }
    }

    //¨***************************   REGISTRO  *************************
    // Método para registrar un nuevo usuario
    public static string RegisterUser(string username, string password)
    {
        try
        {
            Debug.Log("User: " + username + "Pass: " + password);
            // Verificar si el usuario ya existe
            if (UserExists(username))
            {
                return "El usuario ya existe";
            }

            // Si el usuario no existe, proceder con el registro
            var newPlayer = new ModelPlayer
            {
                Nickname = username,
                Password = password,
                Score = 0// Asegúrate de manejar las contraseñas de manera segura (hashing, salting, etc.)
                         // Otros campos del jugador
            };

            _collection.InsertOne(newPlayer);
            return null;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message + e.StackTrace);
            return "Ha ocurrido un error";
        }

    }

    // Método para verificar si un usuario ya existe
    private static bool UserExists(string username)
    {
        var filter = Builders<ModelPlayer>.Filter.Eq("Nickname", username);
        var result = _collection.Find(filter).FirstOrDefault();
        return result != null;
    }

    // TODO
    public static async Task<string> login(string username, string password)
    {
        try
        {
            var filter = Builders<ModelPlayer>.Filter.Eq("Nickname", username) & Builders<ModelPlayer>.Filter.Eq("Password", password);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();

            if (result != null)
            {
                // Inicio de sesión exitoso
                Session session = Session.Sessioninstance;
                session.setLogin(true);
                session.setNickname(result.Nickname);
                session.setID(result.Id.ToString());
                DBMongoInstance.iIdPlayer = result.Id.ToString();
                return "OK";
            }
            else
            {
                // Credenciales incorrectas
                return "Nombre de usuario o contraseña incorrectos";
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al iniciar sesión: " + e.Message);
            return "Ha ocurrido un error al iniciar sesión";
        }
    }

    // **********************   LISTAR PLAYER    ***********************

    // Método para consultar todos los registros en la colección
    public static List<ModelPlayer> ConsultarTodosRegistros()
    {
        try
        {
            var filter = Builders<ModelPlayer>.Filter.Empty; // Filtro vacío para obtener todos los documentos
            var result = _collection.Find(filter).ToList();

            // Ordenar la lista por score de mayor a menor
            result.Sort((a, b) => b.Score.CompareTo(a.Score));

            return result;

        }
        catch (System.Exception e)
        {
            Debug.Log("Error al consultar registros: " + e.Message);
            return null;
        }
    }


    // **********************   OBTENER SCORE    ***********************

    public static int ObtenerScorePorIdPlayer()
    {
        try
        {
            return DBMongoInstance.ObtenerScorePorId();
        }
        catch (System.Exception)
        {
            return 0;
        }
    }

    public int ObtenerScorePorId()
    {
        int score = 0;

        if (_client != null)
        {
            try
            {
                var filter = Builders<ModelPlayer>.Filter.Eq("_id", new ObjectId(DBMongoInstance.iIdPlayer));
                var result = _collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    score = result.Score;
                }
                else
                {
                    Debug.Log("No se encontró el jugador con el ID proporcionado.");
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("ERROR: " + e.Message);
            }
        }

        return score;
    }

    // **********************   ACTUALIZAR SCORE    ***********************

    public static void ActualizarScore(int iPuntuacion)
    {
        if (_client != null)
        {
            try
            {
                if (DBMongoInstance.ObtenerScorePorId() < iPuntuacion)
                {
                    // Define el filtro para identificar el documento que deseas actualizar
                    var filter = Builders<ModelPlayer>.Filter.Eq("_id", new ObjectId(DBMongoInstance.iIdPlayer));
                    // Crea un documento de actualización con los cambios deseados
                    var update = Builders<ModelPlayer>.Update.Set("Score", iPuntuacion);
                    // Ejecuta la operación de actualización
                    _collection.UpdateOne(filter, update);
                }

            }
            catch (System.Exception e)
            {
                Debug.Log("ERROR: " + e.Message);
            }

        }

    }





    // Update is called once per frame
    void Update()
    {

    }
}
