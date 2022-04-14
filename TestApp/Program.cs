// See https://aka.ms/new-console-template for more information

using static Problems;

Problems obj = new Problems();
string _msg = "";

#region For  JollyJumpers
//List<int> valLst = new List<int>();
//valLst.Add(-5);
//valLst.Add(1);
//valLst.Add(4);
//valLst.Add(2);
//valLst.Add(-1);
//valLst.Add(6);

//_msg = obj.JollyJumpers(valLst);
//Console.WriteLine(_msg);
#endregion

#region For  VirtualFriends
//List<string> names = new List<string>();
//List<int> resValList = new List<int>();
//names.Add("Fred Barney");
//names.Add("Barney Betty");
//names.Add("Betty Wilma");
//names.Add("Wilma adam");
//names.Add("ADAM Mohan");

//resValList = obj.VirtualFriends(names, ref _msg);

//if (_msg == null || _msg == "")
//{
//    for (int i = 0; i < resValList.Count; i++)
//    {
//        Console.WriteLine(resValList[i]);
//    }
//}
//else
//{
//    Console.WriteLine(_msg);
//}
#endregion

#region For Egypt
//_msg = obj.Egypt(6,8,10);
//Console.WriteLine(_msg);
#endregion

#region For ImageSize
//bool res = obj.ImageSize(2, ref _msg);
//if (_msg != null || _msg != "")
//{
//    Console.WriteLine(_msg);
//}
#endregion

#region ThreadCall
//obj.threadCall(ref _msg);
//if (_msg != null || _msg != "")
//{
//    Console.WriteLine(_msg);
//}
#endregion
class Problems
{
    public List<int> VirtualFriends(List<string> names, ref string Msg)
    {

        string x = string.Empty, y = string.Empty;
        List<string> res = new List<string>();
        List<int> _valLst = new List<int>();

        try
        {
            for (int i = 1; i <= names.Count; i++)
            {
                if (i == 1)
                {
                    x = names[i - 1].Split(" ")[0];
                    y = names[i - 1].Split(" ").Skip(1).First();
                    res.Add(x);
                    res.Add(y);
                }
                else
                {
                    string temp = names[i - 2].ToLower();
                    x = names[i - 1].Split(" ")[0].ToLower();
                    y = names[i - 1].Split(" ").Skip(1).First().ToLower();
                    foreach (var item in temp.Split(" "))
                    {
                        if (i > 1 && (item.ToLower() == x || item.ToLower() == y))
                        {
                            res.Add(item);
                        }
                    }
                }
                _valLst.Add(res.Count);
            }
            return _valLst;
        }
        catch (Exception ex)
        {
            Msg = "Error in VirtualFriends() " + ex.Message;
            return _valLst;
        }
    }
    public string JollyJumpers(List<int> values)
    {
        string _res = string.Empty;
        int res = 0, val = 0, val2 = 0;
        try
        {
            for (int i = values.Count; i > 0; i--)
            {
                if (i != 1)
                {
                    val = values[i - 2];
                    val2 = values[i - 1];
                    res = val - val2;
                    res = Math.Abs(res);
                    if (res == 1)
                    {
                        _res = "Jolly";
                        break;
                    }
                    else
                    {
                        _res = "Not Jolly";
                    }
                }
            }

            return _res;
        }
        catch (Exception ex)
        {
            return "Error in JollyJumpers() " + ex.Message;
        }
    }
    public string Egypt(int a, int b, int c)
    {
        string str = string.Empty;
        int aMul = 0, bMul = 0, cMul = 0;
        try
        {
            if (a == 0 && b == 0 && c == 0)
            {
                return str = "a,b,c values Cannot be 0";
            }
            else
            {
                aMul = a * a;
                bMul = b * b;
                cMul = c * c;
                if (aMul + bMul == cMul || aMul + cMul == bMul || cMul + bMul == aMul)
                {
                    str = "Right";
                }
                else
                {
                    str = "Wrong";
                }
            }

            return str;
        }
        catch (Exception ex)
        {
            return "Error in Egypt() " + ex.Message;
        }
    }
    public bool ImageSize(int NoOfImage, ref string Msg)
    {
        try
        {
            string[,] arr = new string[0, 0];
            string[,] arr2 = new string[0, 0];
            int[] q = new int[NoOfImage];
            int[] r = new int[NoOfImage];
            for (int i = 0; i < NoOfImage; i++)
            {
                Console.WriteLine("Enter value of q: ");
                q[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter value of r: ");
                r[i] = Convert.ToInt32(Console.ReadLine());
                arr = new string[r[i], r[i]];
                arr2 = new string[q[i], q[i]];

                Console.WriteLine("Enter elements of the Image size: ");
                for (int k = 0; k < r[i]; k++)
                {
                    for (int j = 0; j < r[i]; j++)
                    {
                        arr[k, j] = Console.ReadLine();
                    }
                }
                Console.WriteLine("Printing Image size Matrix: ");
                int reminder = q[i] % r[i];
                int diff = q[i] - r[i];
                if (reminder == 0)
                {
                    for (int k = 0; k < diff; k++)
                    {
                        for (int j = 0; j < diff; j++)
                        {
                            int t = j != 0 ? j + 1 : j;
                            t = arr2[k, t] != null ? t + 1 : t;
                            arr2[k, t] =arr[k, j];
                            arr2[k, t + 1] = arr[k, j];
                        }
                    }
                    int cnt = 1;
                    for (int k = 0; k < q[i]; k++)
                    {
                        for (int j = 0; j < q[i]; j++)
                        {
                            int l = k == 1 ? 0 : k;
                             l = k >1 ? k - cnt : l; 
                            Console.Write(arr2[l, j] + "\t");
                        }
                        Console.WriteLine();
                        int val = q[i] - (r[i] + 1);
                        cnt = k > val ? cnt + 1 : cnt;
                    }
                }
                else
                {
                    Console.WriteLine("Not Possible");
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Msg = "Error in ImageSize() " + ex.Message;
            return false;
        }
    }

    public void threadCall(ref string Msg)
    {
        try
        {
            int id = 0;
            List<int> ThdIdLst = new List<int>();
            for (int i = 1; i < 101; i++)
            {
                if (i<=10)
                {
                    Thread objThd = new Thread(() => GetThreadId(id));
                    objThd.Start();
                    Console.WriteLine($"{i} printed by Thread : {objThd.ManagedThreadId}");
                    ThdIdLst.Add(objThd.ManagedThreadId);
                    objThd.Join();
                }
                else
                {
                    for (int j = 0; j <10; j++)
                    {
                        Console.WriteLine($"{i} printed by Thread : {ThdIdLst[j]}");
                        if (j==9)
                        {
                            i = i;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                
            }
            
        }
        catch (Exception ex)
        {
            Msg= "Error in threadCall() " + ex.Message;
        }
    }
    private int GetThreadId(int id)
    {
        try
        {
            return id=Thread.CurrentThread.ManagedThreadId;    
        }
        catch (Exception)
        {
            throw;
        }
    }

}
