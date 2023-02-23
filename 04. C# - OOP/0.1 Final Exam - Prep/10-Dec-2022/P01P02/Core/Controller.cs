using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            booths.AddModel(new Booth(booths.Models.Count + 1, capacity));
            return string.Format(OutputMessages.NewBoothAdded, booths.Models.Count, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);

            if (delicacyTypeName != nameof(Gingerbread) &&
                delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            if (booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == delicacyName) != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (delicacyTypeName == nameof(Gingerbread))
            {
                IDelicacy delicacy = new Gingerbread(delicacyName);
                booth.DelicacyMenu.AddModel(delicacy);
            }
            else
            {
                IDelicacy delicacy = new Stolen(delicacyName);
                booth.DelicacyMenu.AddModel(delicacy);
            }

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);

            if (cocktailTypeName != nameof(Hibernation) &&
                cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.FirstOrDefault(x => x.Size == size && x.Name == cocktailName) != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (cocktailTypeName == nameof(Hibernation))
            {
                ICocktail cocktail = new Hibernation(cocktailName, size);
                booth.CocktailMenu.AddModel(cocktail);
            }
            else
            {
                ICocktail cocktail = new MulledWine(cocktailName, size);
                booth.CocktailMenu.AddModel(cocktail);
            }

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var firstBooth = booths.Models.Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId).FirstOrDefault();

            if (firstBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            firstBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, firstBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);

            string[] orderParts = order.Split('/');
            string itemTypeName = orderParts[0];
            string itemName = orderParts[1];
            int orderPiecesCount = int.Parse(orderParts[2]);
            string cockTailSize = null;

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                cockTailSize = orderParts[3];
            }

            if (itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName) == null &&
                booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName) == null)
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (cockTailSize != null)
            {
                var cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName && x.Size == cockTailSize);
                if (cocktail == null || cocktail.GetType().Name != itemTypeName)
                    return string.Format(OutputMessages.NotRecognizedItemName, cockTailSize, itemName);

                booth.UpdateCurrentBill(cocktail.Price * orderPiecesCount);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderPiecesCount, itemName);
            }


            var delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName);
            if (delicacy == null || delicacy.GetType().Name != itemTypeName)
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            
            booth.UpdateCurrentBill(delicacy.Price * orderPiecesCount);
            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderPiecesCount, itemName);

        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);
            var currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Bill {currentBill:f2} lv")
                .AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);
            return booth.ToString();
        }
    }
}
