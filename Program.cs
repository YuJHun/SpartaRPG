using static Player;

class Player
{
    public int Level = 5;
    public int Attack = 10;
    public int Defense = 5;
    public int Health = 5;
    public int myGold = 1500;

    public void PrintStatus()
    {
        Console.WriteLine("Lv : " + Level);
        Console.WriteLine("Chad : 전사");
        Console.WriteLine("공격력 : " + Attack);
        Console.WriteLine("방어력 : " + Defense);
        Console.WriteLine("체력 : " + Health);
        Console.WriteLine("Gold : " + myGold);
    }

    public class Item
    {
        public string Name;
        public string Stat;
        public string Description;
        public string Price;

        public Item(string name, string stat, string description, string price)
        {
            Name = name;
            Stat = stat;
            Description = description;
            Price = price;
        }
    }
    string equippedItem = "낡은 검";

    List<Item> inventoryItems = new List<Item>();
    List<Item> shopItems = new List<Item>();

    public void InitGame()
    {
        inventoryItems.Add(new Item("무쇠갑옷", "방어력+5", "무쇠로 만들어져 튼튼한 갑옷", "1000 G"));
        inventoryItems.Add(new Item("스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다.", "1000 G"));
        inventoryItems.Add(new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", "1000 G"));

        shopItems.Add(new Item("수련자의 갑옷", "방어력+5", "수련에 도움을 주는 갑옷입니다", "1000 G"));
        shopItems.Add(new Item("무쇠갑옷", "방어력+5", "무쇠로 만들어져 튼튼한 갑옷", "1000 G"));
        shopItems.Add(new Item("스파르타의 갑옷", "방어력+15", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", "1000 G"));
        shopItems.Add(new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", "1000 G"));
        shopItems.Add(new Item("청동 도끼", "공격력+5", "어디선가 사용됐던거 같은 도끼입니다.", "1000 G"));
        shopItems.Add(new Item("스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다.", "1000 G"));

    }
    public void ShowInventory()
    {
        Console.WriteLine("인벤토리");
        foreach (var item in inventoryItems)
        {
            if (item.Name == equippedItem)
            {
                Console.Write("[ E ]");
            }
            else
            {
                Console.Write("  ");
            }
            Console.WriteLine($"{item.Name} | {item.Stat} | {item.Description} | {item.Price}");
        }
    }
    public void ManageEquipments()
    {
        Console.WriteLine("인벤토리 - 장착관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine("아이템 목록");

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            var invenItem = inventoryItems[i];
            string equipMark = invenItem.Name == equippedItem ? "[E]" : "  ";//invenItem.Name과 장착장비가 같다면 E
            Console.WriteLine($"{i + 1} {equipMark} {invenItem.Name} | {invenItem.Stat} | {invenItem.Description} | {invenItem.Price} ");

        }
        Console.WriteLine("0.나가기");
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        string invenInput = Console.ReadLine();
        if (invenInput == "0")
        {
            return;//메서드에서 return을 선언하면 메서드를 나가게 된다고 한다 void형식이라 리턴값없이 나갈수 있다
        }

        if (int.TryParse(invenInput, out int selectedIndex))
        {
            selectedIndex -= 1;//배열인덱스는 0부터 시작이라
            if (selectedIndex >= 0 && selectedIndex < inventoryItems.Count)
            {
                var selectedItem = inventoryItems[selectedIndex];
                if (equippedItem == selectedItem.Name)
                {
                    Console.WriteLine($"{selectedItem.Name} 장착 해제");
                    equippedItem = "";
                }
                else
                {
                    Console.WriteLine($"{selectedItem.Name} 장착 완료");
                    equippedItem = selectedItem.Name;
                }
            }
            else
            {
                Console.WriteLine("잘못된 번호입니다");
            }
        }
        else
        {
            Console.WriteLine("숫자를 입력해주세요");
        }


    }
    public void ShowShop()
    {
        Console.WriteLine("상점 - 필요한 아이템을 얻을 수 있습니다.");
        Console.WriteLine($"[보유 골드] {myGold}G");
        foreach (var item in shopItems)
        {
            bool alreadyOwned  = inventoryItems.Exists(x => x.Name == item.Name); //inventoryItems.Exists 리스트 안에 조건을 만족하는 요소가 하나라도 있으면 true,없으면 false를 반환

            string 구매완료 = alreadyOwned  ? "구매완료" : item.Price; //조건식 ? 참일_때_값 : 거짓일_때_값;

            Console.WriteLine($"{item.Name} | {item.Stat} | {item.Description} | {구매완료}");
        }
    }

    public void BuyFromShop()
    {
        Console.WriteLine();
        Console.WriteLine("상점 - 아이템 구매");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine($"보유골드 : {myGold}");
        for (int i = 0; i < shopItems.Count; i++)
        {
            var shopItem = shopItems[i];
            bool alreadyOwned = inventoryItems.Exists(x => x.Name == shopItem.Name);//람다식 
                                                                   //즉 x라는 아이템의 이름이 상점아이템의 이름과 같은지 비교하는 코드
                                                                   //inventoryItems 리스트 안의 각 x라는 아이템에 대해,
                                                                   //그 아이템의 이름(x.Name)이 상점item.Name과 같은지 비교
            string 상태 = alreadyOwned ? "구매완료" : shopItem.Price;
            //if (alreadyOwned)
            //{
                Console.WriteLine($"{i + 1}. {shopItem.Name} | {shopItem.Stat} | {shopItem.Description} | {상태}");
            //}
        }
        string shopInput = Console.ReadLine();
        if (shopInput == "0") return;
        if (int.TryParse(shopInput, out int selectedIndex))
        {
            selectedIndex -= 1;
            if (selectedIndex >= 0 && selectedIndex < shopItems.Count)
            {
                var selectedItem = shopItems[selectedIndex];
                bool alreadyOwned = inventoryItems.Exists(x => x.Name == selectedItem.Name);
                if (alreadyOwned)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    return;
                }
                string priceText = selectedItem.Price.Replace("G", "").Replace(" ", "");
                //아이템 가격 문자열을 숫자로 바꾸기 전에, 문자열에서 필요 없는 문자들을 제거하는 작업
                if (int.TryParse(priceText, out int price))
                {
                    if (myGold >= price)
                    {
                        myGold -= price;
                        inventoryItems.Add(selectedItem);
                        Console.WriteLine($"{selectedItem.Name} 을(를) 구매했습니다!");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }

                }
                else
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 번호입니다.");
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {

        Player pInfo = new Player();
        pInfo.InitGame();//인벤토리와 상점 아이템 초기화 (이해되진 않았음)
        string input1;


        do
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("1.상태보기");
            Console.WriteLine("2.인벤토리");
            Console.WriteLine("3.상점");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            input1 = Console.ReadLine();
            if (input1 == "1")
            {


                pInfo.PrintStatus();

                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                input1 = Console.ReadLine();
                if (input1 == "0")
                {
                    continue;
                }

            }
            else if (input1 == "2")
            {
                pInfo.ShowInventory();
                Console.WriteLine("1. 장착관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                input1 = Console.ReadLine();
                if (input1 == "0")
                {
                    continue;
                }
                else if (input1 == "1")
                {
                    pInfo.ManageEquipments();
                }

            }
            else if (input1 == "3")
            {
                pInfo.ShowShop();
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                input1 = Console.ReadLine();
                if (input1 == "0")
                {
                    continue;
                }
                else if (input1 == "1")
                {
                    pInfo.BuyFromShop();
                }

            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Console.WriteLine("");

                continue;



            }
        } while (input1 != "00");
    }
}
