using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Nosotros : ContentPage
    {

        public Nosotros()
        {
            InitializeComponent();

            //ShowText();

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        //private void ShowText()
        //{

        //    string cs = "Mision"+ "<br/> <br/>"+"Dar a nuestros invitados la mejor experiencia de entretenimiento, basada en la comunidad familiar para vivir el gran momento." + "<br/> <br/>" + "VISIÓN" + "<br/><br/>" + "Ser la opción de entretenimiento preferida por nuestros visitantes; reconocidos por la ubicación, calidad y variedad de experiencia, productos y servicio, para compartir buenas emociones." + "<br/><br/>" + "NUESTROS MOTORES" + "<br/><br/>" + "Las personas: Lo más valioso de la empresa son las personas, apoyarnos es consecuencia de resultados a lograr y a generar el orgullo de pertenecer a ParkVille." + "<br/><br/>" + "Vocación de servicio: Nuestra razón de ser son nuestros invitados. Realizamos nuestro trabajo con entusiasmo para contribuir a fortalecer la imagen de nuestra nueva marca." + "<br/><br/>" + "Trabajo en Equipo: Juntos conseguimos construir soluciones y logramos maximizar los resultados, porque nuestros éxitos son el reflejo de todo el equipo." + "<br/><br/>" + "NUESTROS VALORES" + "<br/><br/>" + "Integridad: Actuamos conforme a las normas y reglas de la empresa y del país. Cumpliendo con lo que ofrecemos y esmerándonos en lograrlo." + "<br/><br/>" + "Compromiso: Nos enfocamos en lograr nuestro desempeño, demostrando y fomentando una actitud de esfuerzo y responsabilidad; cada quien pone lo mejor de sí para lograr las metas y cumplir lo comprometido." + "<br/><br/>" + "Respeto: Nos comunicamos con claridad y con fundamentos, siempre en un tono de respeto hacia los demás. Nos expresamos positivamente de las personas, evitando cualquier tipo de comentarios ofensivos o despectivos, sin distingo alguno por sus características individuales o nivel jerárquico." + "<br/><br/>" + "JURAMENTO DE SERVICIO"+ "<br/><br/>" + "1.Nos comprometemos a lograr una experiencia de entretenimiento, con buen servicio, calidad y seguridad en nuestras instalaciones"+ "<br/><br/>"+ "2.Siempre serás bienvenido."+ "<br/><br/>"+ "3.Nuestro personal te brindará la amabilidad y el respeto que te mereces como nuestro invitado."+ "<br/><br/>"+ "4.Nuestras películas serán las mejores disponibles y serán exhibidas tal y como fueron concebidas por sus realizadores, sin intermedios improvisados, con la tecnología en proyección y con un sistema de sonido adecuado a nuestro concepto."+ "<br/><br/>" + "5.Nuestra dulcería te ofrecerán los productos necesarios para vivir la experiencia; con un servicio rápido, eficiente y amable." + "<br/><br/>"+"6.Nuestras instalaciones siempre se mantendran adecuadas a un buen servicio."+"<br/><br/>"+"7.Si te fallamos en alguna de nuestras promesas, por favor, háznoslo saber de inmediato.";
        //    var structure = "<html>" +
        //                    "<body style=\"text-align: justify; color: White; background-color:#BF0000;\">" +
        //                    String.Format("<p>{0}</p>", cs) +
        //                    "</body>" +
        //                    "</html>";
        //    var source = new HtmlWebViewSource();
        //    source.Html = structure;
        //    webtxt.Source = source;

        //}

    }
}