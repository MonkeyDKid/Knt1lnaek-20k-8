using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class OSMberburu : MonoBehaviour
    {
        public string requestData3;
        private UIBubblePopupManager UIBPM;

        private void Start()
        {
            UIBPM = GetComponent<UIBubblePopupManager>();
           // CheckOSM();
        }
        public void CheckOSM()
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
            OnlineMaps.instance.RemoveMarkersByTag("cupu");
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
              markers.tags.Add("cupu");
              markers.OnClick += UIBPM.OnMarkerClick;
              markers.label = randomlabel();
              markers.scale = .2f;
              markers.texture = Resources.Load<Texture2D> ("icon_item/" + markers.label);
//                Debug.Log(way.tags.FirstOrDefault(t => t.key == "name").value);
            }
        }

        private string randomlabel()
        {
            String[] Label = new String[5];
            Label[0] = "Hantu";
            Label[1] = "GoldMarker";
            Label[2] = "Roll";
            Label[3] = "CrystalMarker";
            Label[4] = "Gem";
            var random = UnityEngine.Random.Range(0,4);
            return Label[random];
            
        }
    }
