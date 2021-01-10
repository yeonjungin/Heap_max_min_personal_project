using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public static Label[] label_list;
        public static TableLayoutPanel[] table_list;
        public Form1()
        {
            InitializeComponent();
            label_list = new Label[] { label1, label2, label3, label4, label29, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15 };
            // 라벨 리스트 생성해서 라벨 정보 넣기 (노드 번호를 나타내는 정보성 라벨)

            table_list = new TableLayoutPanel[]  // 테이블 panel 리스트 생성해서 정보 넣기 (노드 뒷배경을 나타내기 위한 패널)
            {
                tableLayoutPanel1,tableLayoutPanel2,
                tableLayoutPanel3,tableLayoutPanel4,tableLayoutPanel5,tableLayoutPanel6,tableLayoutPanel7,
                tableLayoutPanel8,tableLayoutPanel9,tableLayoutPanel10,tableLayoutPanel11,tableLayoutPanel12,
                tableLayoutPanel13,tableLayoutPanel14,tableLayoutPanel15,

            };
            // visible=false로 줘서 윈폼에는 버튼 이외에는 아무런 정보가 표시되지 않도록 지정.
            for (int i = 0; i < 15; i++)
            {
                label_list[i].Visible = false;
                table_list[i].Visible = false;
            }
            // 버튼 이벤트에 선언하면 버튼 누를때마다 축적되서 stop하고 다시 start시에는 함수가
            //여러번 발생하기 떄문에 form1()안에 선언한다. 그래야 1번 축적된다.
            _oTimer.Interval = 2000;
            _oTimer.Tick += new EventHandler(_oTimer_Tick);
            _oTimer2.Interval = 2000;
            _oTimer2.Tick += _oTimer2_Tick;
        }
        // 추가버튼을 누르면 fDataIn메소드가 실행된다.
        private void AddBtn_Click(object sender, EventArgs e)
        {
            fDataIn();
        }
        private void fDataIn()
        {
            Label[] lb = new Label[] { a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15 };
            // lb라는 라벨 배열을 만들어서 숫자를 나타내게 하는 라벨의 정보들을 넣는다
            Random random = new Random();// 랜덤을 이용해서 난수를 생성한다.
            int winning_number = random.Next(0, 151);// 0부터 150까지의 숫자들 중에서 랜덤으로 숫자를 winning_number에 넣는다.
            if (MaxHeap.node.Count == 0)// 만약 노드의 count가 0이면 key값은 0으로 넘겨주고 , true를 넘겨준다. 그리고 난뒤 return;
            {
                MaxHeap.insert(0, true);
                return;
            }
            // 노드의 카운트가 0이 아닐경우
            else
            {
                removenumTxt1.Text = "";
                removenumTxt2.Text = "";
                addnumTxt.Text = "추가된 노드의 값 : "; // 추가된 노드의 값을 알려주는 안내문1
                addnumTxt2.Text = winning_number.ToString();// 추가된 노드의 값을 알려주는 안내문2

                if (MaxHeap.node.Count < 16) // 만약 노드의 카운트가 15개이하일 경우에만 실행된다.
                {
                    MaxHeap.insert(winning_number, false); //Maxheap insert 메소드 실행, 매개변수에는 난수를 넣어준다.
                    
                    for (int i = 0; i < MaxHeap.node.Count - 1; i++)
                    {
                        // for문을 이용해서 노드의 개수에 맞춰서 노드의 개수를 알려주는 라벨과 테이블패널의 visible을 true로 바꿔서 
                        // 폼에 나타나도록 한다.
                        label_list[i].Visible = true;
                        table_list[i].Visible = true;
                        
                    }
                    
                        int num = MaxHeap.node.Count; // num에는 현재 노드의 count를 대입

                        lb[0].Text = ""; // lb[0]에는 쓰레기값 0을 넣었으므로 표시가 되기때문에 ""를 통해 폼화면에는 아무것도 나타나지 않도록 함.
                        for (int i = 1; i < num; i++)
                        {
                            lb[i].Text = MaxHeap.node[i].ToString();                           
                            //노드 숫자의 값들을 입력해준다.
                        }                   
                }
                else
                {
                    //노드의 카운트가 16을 넘어갈 경우에는 더이상 추가 할 수 없다는 안내문을 출력해준다.
                    MessageBox.Show("더이상 추가할 수 없습니다.");
                    addnumTxt.Text = "더이상 추가 할 수 없습니다. ";
                    addnumTxt2.Text = "";
                }

            }
        }
        // 삭제버튼을 누를때마다 fDataOut메소드가 실행된다.
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            fDataOut();
        }
        private void fDataOut()
        {
            if (MaxHeap.isEmpty()) // 만약 힙이 비어있으면 삭제 할 수 없도록 안내문을 입력해준다.
            {
                MessageBox.Show("삭제 할 수 있는 노드가 존재하지 않습니다.");
                addnumTxt.Text = "";
                addnumTxt2.Text = "";
                removenumTxt1.Text = "더이상 삭제를 할 수 없습니다.";
                removenumTxt2.Text = "";
            }
            else
            {
                addnumTxt.Text = "";
                addnumTxt2.Text = "";
                removenumTxt1.Text = "삭제된 루트 노드 :";
                removenumTxt2.Text = MaxHeap.node[1].ToString();  // 삭제할 뿌리노드를 폼화면에 출력해주는 역할
                MaxHeap.remove();  // MaxHeap remove실행
                int num = MaxHeap.node.Count - 1;
                Label[] lb = new Label[] { a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15 };
                lb[num + 1].Text = ""; // 삭제 하기전 맨 마지막 노드의 정보를 삭제를 한 이후에는 폼 화면에 나타내지 않기 위해 공백을 넣어준다.
                table_list[num].Visible = false;  // 맨 마지막 노드 자리에 아무것도 출력되지 않도록 해준다.
                label_list[num].Visible = false;

                for (int i = num; i > 0; i--)
                {
                    lb[i].Text = MaxHeap.node[i].ToString();
                }
            }
        }
        Timer _oTimer = new Timer();
        bool _bTimer = false;   // Timer 스위치
        /* 자동 추가 타이머 AutoAdd*/
        private void AutoAddBtn_Click(object sender, EventArgs e)
        {
            if (_bTimer)
            {
                _oTimer.Stop();
                _bTimer = false;
                MessageBox.Show("자동 삽입 실행을 중단하였습니다.");
            }
            else
            {
                _oTimer.Start();
                _bTimer = true;
            }
        }
        private void _oTimer_Tick(object sender, EventArgs e)
        {
            if (MaxHeap.node.Count < 16)
            {
                fDataIn();
            }            
        }
        /* 자동 삭제 타이머 AutoRemove */
        Timer _oTimer2 = new Timer();
        bool _bTimer2 = false;   // Timer 스위치
        private void _oTimer2_Tick(object sender, EventArgs e)
        {
            if (MaxHeap.node.Count > 1)
            {
                fDataOut();
            }
        }
        // 자동 삭제 버튼
        private void AutoRemoveBtn_Click(object sender, EventArgs e)
        {
            if (_bTimer2)
            {
                _oTimer2.Stop();
                _bTimer2 = false;
                MessageBox.Show("자동 삭제 실행을 중단하였습니다.");
            }
            else
            {
                _oTimer2.Start();
                _bTimer2 = true;
            }
        }
        // 메뉴버튼을 클릭하면 메뉴화면 폼으로 이동한다.
        private void MenuBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
   

