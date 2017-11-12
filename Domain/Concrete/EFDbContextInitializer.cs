using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{


    public static class EFDbContextInitializer
    {
        public static void Initialize(EFDbContext context)
        {
            context.Database.EnsureCreated();

            
            if (context.RequestsStore.Any())
            {
                return;   
            }

            var statuses = new List<Statuses>
            {
                new Statuses { Name="Открыта"},
                new Statuses { Name="Решена"},
                new Statuses { Name ="Возврат"},
                new Statuses { Name="Закрыта"}
                            };
            foreach (var item in statuses)
            {
                context.Statuses.Add(item);
            }
            context.SaveChanges();

            var requestStore = new List<RequestsStore>
            {
                new RequestsStore {
                    Date =DateTime.Now.AddDays(-10),
                    StatusId=1,
                    Comments="Заявка создана",
                    Requests=new Requests
                    {
                         CreateDate=DateTime.Now.AddDays(-10),
                         Name="Что такое Lorem Ipsum?",
                         Content="<ul><li>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</li><li>Vivamus suscipit ante at urna efficitur blandit.</li><li>Nam venenatis tellus id velit rhoncus, in finibus augue malesuada.</li></ul></p>"
                    }
                },
                    new RequestsStore {
                    Date =DateTime.Now.AddDays(-9),
                    StatusId=1,
                    Comments="Заявка создана",
                    Requests=new Requests
                    {
                         CreateDate=DateTime.Now.AddDays(-9),
                         Name="Откуда появился Lorem Ipsum?",
                         Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },
                    new RequestsStore {
                    Date =DateTime.Now.AddDays(-8),
                    StatusId=1,
                    Comments="Заявка создана",
                    Requests=new Requests
                    {
                         CreateDate=DateTime.Now.AddDays(-8),
                         Name="Почему он используется?",
                         Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },
                    new RequestsStore {
                    Date =DateTime.Now.AddDays(-7),
                    StatusId=1,
                    Comments="Заявка создана",
                    Requests=new Requests
                    {
                        CreateDate=DateTime.Now.AddDays(-7),
                        Name ="Где взять Lorem Ipsum?",
                        Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },
                   new RequestsStore {
                   Date =DateTime.Now.AddDays(-6),
                   StatusId=1,
                   Comments="Заявка создана",
                   Requests=new Requests
                    {
                         CreateDate=DateTime.Now.AddDays(-6),
                         Name="Классический текст Lorem Ipsum, используемый с XVI века",
                         Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },
                   new RequestsStore {
                   Date =DateTime.Now.AddDays(-5),
                   StatusId=1,
                   Comments="Заявка создана",
                   Requests=new Requests
                    {
                        CreateDate=DateTime.Now.AddDays(-5),
                         Name="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras.",
                         Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },
                   new RequestsStore {
                   Date =DateTime.Now.AddDays(-4),
                   StatusId=1,
                   Comments="Заявка создана",
                   Requests=new Requests
                    {
                         CreateDate=DateTime.Now.AddDays(-4),
                         Name="Lorem sit amet, adipiscing elit.",
                         Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },
                    new RequestsStore {
                   Date =DateTime.Now.AddDays(-3),
                   StatusId=1,
                   Comments="Заявка создана",
                   Requests=new Requests
                    {
                         CreateDate=DateTime.Now.AddDays(-3),
                         Name="What is Lorem Ipsum?",
                         Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },
                   new RequestsStore {
                   Date =DateTime.Now.AddDays(-2),
                   StatusId=1,
                   Comments="Заявка создана",
                   Requests =new Requests
                    {
                         CreateDate=DateTime.Now.AddDays(-2),
                         Name="Lorem ipsum dolor sit amet.",
                         Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },
                   new RequestsStore {
                   Date =DateTime.Now.AddDays(-1),
                   StatusId=1,
                   Comments="Заявка создана",
                   Requests=new Requests
                    {
                         CreateDate=DateTime.Now.AddDays(-1),
                         Name="Lorem ipsum dolor sit amet, consectetur adipiscing.",
                         Content="<ul><li>Sed venenatis dui molestie libero elementum ultrices.</li><li>Vestibulum placerat risus eu odio accumsan viverra.</li><li>Nullam et sem ut purus egestas rutrum.</li><li>Praesent auctor tellus et mi rutrum, vel lacinia tortor luctus.</li><li>Nam at tortor euismod, gravida mi fringilla, laoreet magna.</li><li>Maecenas dictum ligula eu nibh mattis, eu pulvinar mi sodales.</li></ul>"
                    }
                },


            };

            foreach (var item in requestStore)
            {
                context.RequestsStore.Add(item);
            }

            context.SaveChanges();
        }
    }

}
