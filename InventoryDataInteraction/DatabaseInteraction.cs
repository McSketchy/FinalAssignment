using InventoryData;
using InventoryDataInteraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using InventoryDataMapping.Models;

namespace InventoryDataInteraction
{

	public class DatabaseInteraction //: IInventoryData, IUserRepository
	{


    //    public ienumerable<order> getorders()
    //    {
    //        using (var db = new inventorycontext())
    //        {
    //            return (from order in db.orders.include("orderitems")
    //                                           .include("orderitems.item")
    //                                           .include("purchaser")
    //                    select order).tolist();
    //        }
    //    }

    //    public ienumerable<item> getitems()
    //    {
    //        using (var db = new inventorycontext())
    //        {
    //            return (from item in db.items
    //                    select item).tolist();
    //        }
    //    }

    //    public ienumerable<orderitem> getorderitems(int ordernumber)
    //    {
    //        using (var db = new inventorycontext())
    //        {
    //            return (from orderitem in db.orderitems
    //                    where orderitem.ordernumber == ordernumber
    //                    select orderitem).tolist();
    //        }
    //    }

    //    public bool saveorder(order order)
    //    {
    //        if (order == null)
    //            return false;

    //        try
    //        {
    //            using (var db = new inventorycontext())
    //            {
    //                db.orders.add(order);
    //                db.savechanges();
    //            }
    //            return true;
    //        }
    //        catch (exception e)
    //        {
    //            return false;
    //        }
    //    }

    //    public bool saveitem(item item)
    //    {
    //        if (item == null)
    //            return false;

    //        try
    //        {
    //            using (var db = new inventorycontext())
    //            {
    //                db.items.add(item);
    //                db.savechanges();
    //            }
    //            return true;
    //        }
    //        catch (exception e)
    //        {
    //            return false;
    //        }
    //    }

    //    public bool saveorderitem(int ordernumber, orderitem orderitem)
    //    {
    //        if (orderitem == null)
    //            return false;

    //        try
    //        {
    //            using (var db = new inventorycontext())
    //            {
    //                var order = (from o in db.orders
    //                             where o.ordernumber == ordernumber
    //                             select o).singleordefault();

    //                if (order == null)
    //                    return false;

    //                order.orderitems.add(orderitem);
    //                db.orderitems.add(orderitem);
    //                db.savechanges();
    //            }

    //            return true;
    //        }
    //        catch (exception e)
    //        {
    //            return false;
    //        }
    //    }

    //    public ienumerable<user> getusers()
    //    {
    //        using (var db = new inventorycontext())
    //        {
    //            return (from user in db.users
    //                    select user).tolist();
    //        }
    //    }

    //    public bool saveuser(user user)
    //    {
    //        if (user == null)
    //            return false;

    //        try
    //        {
    //            using (var db = new inventorycontext())
    //            {
    //                db.users.add(user);
    //                db.savechanges();
    //            }
    //            return true;
    //        }
    //        catch (exception e)
    //        {
    //            return false;
    //        }
    //    }

    //    public ienumerable<order> getuserorders(int userid)
    //    {
    //        using (var db = new inventorycontext())
    //        {
    //            return (from u in db.userorders
    //                    where u.userid == userid
    //                    select u.order).tolist();
    //        }
    //    }


    //    public task<ienumerable<order>> getordersasync()
    //    {
    //        var factory = new taskfactory<ienumerable<order>>();
    //        return factory.startnew(() =>
    //        {
    //            return this.getorders();
    //        });
    //    }

    //    public task<ienumerable<item>> getitemsasync()
    //    {
    //        var factory = new taskfactory<ienumerable<item>>();
    //        return factory.startnew(() =>
    //        {
    //            return getitems();
    //        });
    //    }

    //    public task<ienumerable<orderitem>> getorderitemsasync(int ordernumber)
    //    {
    //        var factory = new taskfactory<ienumerable<orderitem>>();
    //        return factory.startnew(() =>
    //        {
    //            return getorderitems(ordernumber);
    //        });
    //    }

    //    public task<bool> saveorderasync(order order)
    //    {
    //        var factory = new taskfactory<bool>();
    //        return factory.startnew(() =>
    //        {
    //            return saveorder(order);
    //        });
    //    }

    //    public task<bool> saveitemasync(item item)
    //    {
    //        var factory = new taskfactory<bool>();
    //        return factory.startnew(() =>
    //        {
    //            return saveitem(item);
    //        });
    //    }

    //    public task<bool> saveorderitemasync(int ordernumber, orderitem orderitem)
    //    {
    //        var factory = new taskfactory<bool>();
    //        return factory.startnew(() =>
    //        {
    //            return saveorderitem(ordernumber, orderitem);
    //        });
    //    }

    //    public task<ienumerable<user>> getusersasync()
    //    {
    //        return new taskfactory<ienumerable<user>>().startnew(this.getusers);
    //    }

    //    public task<bool> saveuserasync(user user)
    //    {
    //        return new taskfactory<bool>().startnew(() => this.saveuser(user));
    //    }

    //    public task<ienumerable<order>> getuserordersasync(int userid)
    //    {
    //        return new taskfactory<ienumerable<order>>().startnew(() => this.getuserorders(userid));
    //    }
    }
}
