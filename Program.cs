class Player
{
    public int Level = 5;
    public int Attack = 10;
    public int Defense = 5;
    public int Health = 5;
    public int Gold = 1500;

    public void PrintStatus()
    {
        Console.WriteLine("Lv : " + Level);
        Console.WriteLine("Chad : 전사");
        Console.WriteLine("공격력 : " + Attack);
        Console.WriteLine("방어력 : " + Defense);
        Console.WriteLine("체력 : " + Health);
        Console.WriteLine("Gold : " + Gold);
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
    string 장착장비 = "낡은 검";

    List<Item> 인벤토리아이템 = new List<Item>();
    List<Item> 상점아이템 = new List<Item>();

    public void Game()
    {
        인벤토리아이템.Add(new Item("무쇠갑옷", "방어력+5", "무쇠로 만들어져 튼튼한 갑옷","1000 G"));
        인벤토리아이템.Add(new Item("스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다.", "1000 G"));
        인벤토리아이템.Add(new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", "1000 G"));

        상점아이템.Add(new Item("수련자의 갑옷", "방어력+5", "수련에 도움을 주는 갑옷입니다", "1000 G"));
        상점아이템.Add(new Item("무쇠갑옷", "방어력+5", "무쇠로 만들어져 튼튼한 갑옷", "1000 G"));
        상점아이템.Add(new Item("스파르타의 갑옷", "방어력+15", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", "1000 G"));
        상점아이템.Add(new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", "1000 G"));
        상점아이템.Add(new Item("청동 도끼", "공격력+5", "어디선가 사용됐던거 같은 도끼입니다.", "1000 G"));
        상점아이템.Add(new Item("스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다.", "1000 G"));

    }
    public void 인벤토리()
    {
        Console.WriteLine("인벤토리");
        foreach (var item in 인벤토리아이템)
        {
            if (item.Name == 장착장비)
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
    public void 상점()
    {
        Console.WriteLine("▶ 상점 - 필요한 아이템을 얻을 수 있습니다.");
        Console.WriteLine($"[보유 골드] {Gold}G");
        foreach (var item in 상점아이템)
        {
            bool 이미보유 = 인벤토리아이템.Exists(x => x.Name == item.Name); //인벤토리아이템.Exists 리스트 안에 조건을 만족하는 요소가 하나라도 있으면 true,없으면 false를 반환

            string 구매완료 = 이미보유 ? "구매완료" : item.Price; //조건식 ? 참일_때_값 : 거짓일_때_값;

            Console.WriteLine($"{item.Name} | {item.Stat} | {item.Description} | {구매완료}");
        }
    }
    //string 장착장비 = "낡은 검";
    //String[] 무쇠갑옷 = { "무쇠갑옷", "방어력+5", "무쇠로 만들어져 튼튼한 갑옷" };
    //String[] 스파르타의창 = { "스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다." };
    //String[] 낡은검 = { "낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다." };
    //public void 인벤토리()
    //{

    //    if (장착장비 == 무쇠갑옷[0])
    //    {
    //        Console.Write("[E]");
    //    }
    //    Console.WriteLine(무쇠갑옷[0] + " | " + 무쇠갑옷[1] + " | " + 무쇠갑옷[2]);
    //    if (장착장비 == 스파르타의창[0])
    //    {

    //        Console.Write("[E]");
    //    }
    //    Console.WriteLine(스파르타의창[0] + " | " + 스파르타의창[1] + " | " + 스파르타의창[2]);
    //    if (장착장비 == 낡은검[0])
    //    {

    //        Console.Write("[E]");
    //    }
    //    Console.WriteLine(낡은검[0] + " | " + 낡은검[1] + " | " + 낡은검[2]);
    //}


    //string[] 수련자의갑옷 = {"수련자의 갑옷","방어력+5","수련에 도움을 주는 갑옷입니다" };
    //string[] 스팔르타의갑옷 = {"스파르타의 갑옷","방어력+15","스파르타의 전사들이 사용했다는 전설의 갑옷입니다." };
    //string[] 청동도끼 = {"청동 도끼","공격력+5","어디선가 사용됐던거 같은 도끼입니다." };
    //public void 상점()
    //{
    //    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
    //    Console.WriteLine("[보유골드]");
    //    Console.WriteLine($"{Gold}G");
    //    Console.WriteLine(수련자의갑옷[0] + " | " + 수련자의갑옷[1] + " | " + 수련자의갑옷[2]);
    //    Console.WriteLine(무쇠갑옷[0] + " | " + 무쇠갑옷[1] + " | " + 무쇠갑옷[2]);
    //    Console.WriteLine(스팔르타의갑옷[0] + " | " + 스팔르타의갑옷[1] + " | " + 스팔르타의갑옷[2]);
    //    Console.WriteLine(낡은검[0] + " | " + 낡은검[1] + " | " + 낡은검[2]);
    //    Console.WriteLine(청동도끼[0] + " | " + 청동도끼[1] + " | " + 청동도끼[2]);
    //    Console.WriteLine(스파르타의창[0] + " | " + 스파르타의창[1] + " | " + 스파르타의창[2]);
    //}
}
class Program
{

    static void Main(string[] args)
    {

        Player pInfo = new Player();
        pInfo.Game();//인벤토리와 상점 아이템 초기화 (이해되진 않았음)
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
                pInfo.인벤토리();
                Console.WriteLine("1. 장착관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                input1 = Console.ReadLine();
                if (input1 == "0")
                {
                    continue;
                }else if (input1 == "1")
                {

                }

            }
            else if (input1 == "3")
            {
                pInfo.상점();
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