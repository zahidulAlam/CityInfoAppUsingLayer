using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CityInfoApp.DAL;
using CityInfoApp.Model;

namespace CityInfoApp.BLL
{
    class Manager
    {
        Gateway gateway = new Gateway();
        public string Save(City aCity)
        {

            if (aCity.CityName.Length > 3)
            {
                if (gateway.IsCityNameExist(aCity.CityName)== false)
                {

                    if (gateway.Save(aCity) > 0)
                    {
                        return "Successfully saved";
                    }
                    else
                    {
                        return "Save failed";
                    }
                }
                else
                {
                   return  "City Name Already exist!";
                }

            }
            else
            {
                return "City name must be at least 4 characters long";
            }
        }



    }
}
