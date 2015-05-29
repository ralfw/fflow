using fflow.body.data;

namespace fflow.body
{
    public interface IBody
    {
        StationInfo[] Get_stations(string workflowpath);
        StationDetails Get_station_documents(string workflowpath, string stationname);
        DocumentInfo Edit(string workflowpath, string stationname, string documentfilename);
        DocumentInfo Push(string workflowpath, string stationname, string documentfilename, string actionname);
    }
}