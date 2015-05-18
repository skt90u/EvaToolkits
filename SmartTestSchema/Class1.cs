using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTestSchema
{
    public class Class1
    {
        public static void a()
        {
            Entities1 ctx = new Entities1();

            ctx.PSD_LEADTIME_INFO.Add(new PSD_LEADTIME_INFO { ITEM  = "ABC", DESCRIPTION = "ABC"});
            ctx.SaveChanges();
            //Entities ctx = new Entities();

            //PSD_LEADTIME_INFO data = new PSD_LEADTIME_INFO();

            //ctx.PSD_LEADTIME_INFO.Add(null);

            //data.ADMIN = 
            ////新增一筆資料
            //PLAYER p = new PLAYER()
            //{
            //    ID = 1,
            //    NAME = "Jeffrey",
            //    REGDATE = new DateTime(2012, 4, 1),
            //    SCORE = 32767
            //};
            //ctx.PLAYER.AddObject(p);
            //ctx.SaveChanges();
            //查詢資料

        }
    }
}
