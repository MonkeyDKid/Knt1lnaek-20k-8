/*     INFINITY CODE 2013-2018      */
/*   http://www.infinity-code.com   */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
    
    /// <summary>
    /// Example of how to make a request to Open Street Map Overpass API and handle the response.
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/OSMRequestExample")]
    public class OSMRequestExample : MonoBehaviour
    {
        public string requestData3;
        private void Start()
        {
            // Get map corners
            Vector2 topLeft = OnlineMaps.instance.topLeftPosition;
            Vector2 bottomRight = OnlineMaps.instance.bottomRightPosition;

            // Create OSM Overpass request where highway is primary or residential
            string requestData = String.Format("node({0},{1},{2},{3});way(bn)[{4}];(._;>;);out;",
                bottomRight.y, topLeft.x, topLeft.y, bottomRight.x, "'highway'~'primary|residential'");
            string requestData2 =  String.Format("node[shop=convenience]({0},{1},{2},{3});(._;>;);out;",bottomRight.y, topLeft.x, topLeft.y, bottomRight.x);
            requestData3 = String.Format("area(3600304751)->.searchArea; node[shop=convenience](area.searchArea)({0},{1},{2},{3});(._;>;); out;",bottomRight.y, topLeft.x, topLeft.y, bottomRight.x);
            // Send request and subscribe to complete event
            OnlineMapsOSMAPIQuery.Find(requestData3).OnComplete += OnComplete;
        }

      
      

        /// This event called when the request is completed.
        private void OnComplete(string response)
        {
            List<OnlineMapsOSMNode> nodes;
            List<OnlineMapsOSMWay> ways;
            List<OnlineMapsOSMRelation> relations;
             print(response);
            // Get nodes, ways and relations from response
            OnlineMapsOSMAPIQuery.ParseOSMResponse(response, out nodes, out ways, out relations);           
           print(nodes.Count);
            foreach (OnlineMapsOSMNode way in nodes)
            {
                // Log highway type
              OnlineMapsMarker markers = OnlineMaps.instance.AddMarker(way.lon, way.lat);
//                Debug.Log(way.tags.FirstOrDefault(t => t.key == "name").value);
            }
        }
    }
}