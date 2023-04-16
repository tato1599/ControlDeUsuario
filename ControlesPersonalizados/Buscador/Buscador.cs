using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados.Buscador
{
    public partial class Buscador : UserControl
    {
        public Buscador()
        {
            InitializeComponent();
        }

        private string clientID ="";
        private string clientSecret="";

        public string ClientID { get => clientID; set => clientID = value; }
        public string ClientSecret { get => clientSecret; set => clientSecret = value; }

        public string token()
        {
           

            try
            {
                string credenciales = String.Format("{0}:{1}", clientID, clientSecret);
                byte[] credencialesBytes = Encoding.UTF8.GetBytes(credenciales);
                string credencialesBase64 = Convert.ToBase64String(credencialesBytes);

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credencialesBase64);

                var parametros = new Dictionary<string, string>
             {
                 { "grant_type", "client_credentials" }
            };



                var content = new FormUrlEncodedContent(parametros);

                var respuesta = client.PostAsync("https://accounts.spotify.com/api/token", content);
                var json = respuesta.Result.Content.ReadAsStringAsync().Result;
                JsonNode rootNode = JsonObject.Parse(json);

                if (rootNode != null && rootNode["access_token"] != null)
                {
                    string token = rootNode["access_token"].ToString();
                   
                    return token;
                }
                else
                {
                
                    MessageBox.Show("No se encontró el token de acceso en la respuesta JSON verifique el clientID y el clientSecret.");
                    return null;
                }

               



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }


        private void btnbuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            try
            {
                dgvCanciones.Rows.Clear();
                HttpClient con = new HttpClient();

                con.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token()); // Agregar token a la solicitud


                var url = "https://api.spotify.com/v1/search?q=" + tbbuscar.Text + "&type=track&offset=0&limit=20";

                var respuesta = con.GetAsync(url).Result;

                string contenido = respuesta.Content.ReadAsStringAsync().Result;


                JsonDocument doc = JsonDocument.Parse(contenido);
                JsonElement root = doc.RootElement;

                int musicaCant = root.GetProperty("tracks").GetProperty("items").GetArrayLength();



                for (int i = 0; i < musicaCant; i++)
                {
                    //llenar data grid view
                    dgvCanciones.Rows.Add(JsonObject.Parse(contenido)["tracks"]["items"][i]["name"].ToString(), JsonObject.Parse(contenido)["tracks"]["items"][i]["artists"][0]["name"].ToString(), JsonObject.Parse(contenido)["tracks"]["items"][i]["preview_url"].ToString());


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning");

            }
        }

        private void Buscador_Load(object sender, EventArgs e)
        {

        }

        private void dgvCanciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                string url = dgvCanciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();


                if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                {

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = $"/c start {url}",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    });
                }
            }
        }

        private void tbbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar();
            }
        }
    }
}
