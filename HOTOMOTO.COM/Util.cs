using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.COM
{
    public class Util
    {
        public static DataTable InitializeRoomsDetail() {
            DataTable dtRoomsDetail = new DataTable();

            dtRoomsDetail.Columns.Add(new DataColumn("RoomIndex"));
            dtRoomsDetail.Columns.Add(new DataColumn("AdultCount"));
            dtRoomsDetail.Columns.Add(new DataColumn("ChildCount"));
            dtRoomsDetail.Columns.Add(new DataColumn("FirstChildAge"));
            dtRoomsDetail.Columns.Add(new DataColumn("SecondChildAge"));

            return dtRoomsDetail;
        }
    }
}
