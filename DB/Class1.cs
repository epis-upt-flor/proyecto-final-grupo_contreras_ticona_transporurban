//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.UI.WebControls;

//namespace Project.DB
//{
//    public class Class1
//    {
//private List<LatLng> decodePoly(String encoded)
//{

//    List<LatLng> poly = new ArrayList<LatLng>();
//    int index = 0, len = encoded.length();
//    int lat = 0, lng = 0;

//    while (index < len)
//    {
//        int b, shift = 0, result = 0;
//        do
//        {
//            b = encoded.charAt(index++) - 63;
//            result |= (b & 0x1f) << shift;
//            shift += 5;
//        } while (b >= 0x20);
//        int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
//        lat += dlat;

//        shift = 0;
//        result = 0;
//        do
//        {
//            b = encoded.charAt(index++) - 63;
//            result |= (b & 0x1f) << shift;
//            shift += 5;
//        } while (b >= 0x20);
//        int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
//        lng += dlng;

//        LatLng p = new LatLng((((double)lat / 1E5)),
//                (((double)lng / 1E5)));
//        poly.add(p);
//    }

//    return poly;
//}


//        map.setOnMapLongClickListener(new GoogleMap.OnMapLongClickListener() {
//            @Override
//        public void onMapLongClick(LatLng latLng)
//        {

//            String snippet = String.format(Locale.getDefault(),
//                    "Lat: %1$.5f, Long: %2.5f",
//                    latLng.latitude, latLng.longitude);

//            if (marcadorSeleccionIR == null)
//            {
//                marcadorSeleccionIR = map.addMarker(new MarkerOptions()
//                        .icon(BitmapDescriptorFactory
//                                .defaultMarker(BitmapDescriptorFactory.HUE_BLUE))
//                        .position(latLng)
//                        .title("Punto más cerca")
//                        .snippet(snippet));

//            }
//            else
//            {
//                marcadorSeleccionIR.setPosition(latLng);
//            }
//            int resultadosdebusqueda = 0;
//            for (Ruta_Yan objbut: rutas)
//            {
//                Boolean condicionInicio = false;
//                Boolean condicionFinal = false; ;
//                for (int z = 0; z < objbut.getListlatlng().size(); z++)
//                {
//                    condicionInicio = consultaPuntoCerca(0.00180, objbut.getListlatlng().get(z), marcadorSeleccionUB.getPosition()); donde me encuentro
//                    if (condicionInicio) break;
//                }
//                for (int y = 0; y < objbut.getListlatlng().size(); y++)
//                {
//                    condicionFinal = consultaPuntoCerca(0.00180, objbut.getListlatlng().get(y), marcadorSeleccionIR.getPosition()); donde quiero ir
//                    if (condicionFinal) break;
//                }
//                if (condicionFinal && condicionInicio)
//                {

//                    objbut.getMuchalinea().setWidth(20);
//                    objbut.getMuchalinea().setZIndex(1);

//                    //GUARDATO HISTORIAL
//                    Map<String, Object> dataHistorial = new HashMap<>();
//                    dataHistorial.put("NombreRuta", objbut.getNombre());
//                    dataHistorial.put("Fecha", android.text.format.DateFormat.format("yyyy-MM-dd", new java.util.Date()));
//                    dataHistorial.put("Hora", android.text.format.DateFormat.format("hh:mm:ss a", new java.util.Date()));
//                    dataHistorial.put("Usuario", MainActivity.usu.getId());
//                    dataHistorial.put("lat_final", latLng.latitude);
//                    dataHistorial.put("lat_inicio", marcadorSeleccionUB.getPosition().latitude);
//                    dataHistorial.put("lon_final", latLng.longitude);
//                    dataHistorial.put("lon_inicio", marcadorSeleccionUB.getPosition().longitude);
//                    mDatabase.child("Historial").push().setValue(dataHistorial);
//                    resultadosdebusqueda++;

//                }
//                else
//                {
//                    objbut.getMuchalinea().setVisible(false);
//                    objbut.getMuchalinea().setWidth(6);
//                    objbut.getMuchalinea().setZIndex(0);
//                }
//            }
//            if (resultadosdebusqueda == 0)
//            {
//                alertas.showAlertrutalejos();

//                for (Ruta_Yan objbut: rutas)
//                {
//                    objbut.getMuchalinea().setVisible(true);
//                    objbut.getMuchalinea().setWidth(6);
//                    objbut.getMuchalinea().setZIndex(0);

//                }
//            }

//        }
//    })
//        ;

//    }

//private Boolean consultaPuntoCerca(double cercania, LatLng pruta, LatLng prutaconsulta)
//{
//    double longitud = pruta.longitude - (prutaconsulta.longitude);
//    double latitud = pruta.latitude - (prutaconsulta.latitude);

//    double resultadomodulo = Math.sqrt(longitud * longitud + latitud * latitud);

//    if (cercania > resultadomodulo) return true;
//    return false;

//}
//    }
//