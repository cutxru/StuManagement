using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication7.ViewModel
{
    public class AddStudentViewModel:ViewModelBase
    {
        #region  绑定的属性值
        private string stu_id;
        public string Stu_id
        {
            get { return stu_id; }
            set
            {
                Set(ref stu_id, value);
            }
        }

        private string stu_name;
        public string Stu_name
        {
            get { return stu_name; }
            set
            {
                Set(ref stu_name, value);
            }
        }

        private string stu_class;
        public string Stu_class
        {
            get { return stu_class; }
            set
            {
                Set(ref stu_class, value);
            }
        }

        private string stu_gender;
        public string Stu_gender
        {
            get { return stu_gender; }
            set
            {
                Set(ref stu_gender, value);
            }
        }

        private int stu_age;
        public int Stu_age
        {
            get { return stu_age; }
            set
            {
                Set(ref stu_age, value);
            }
        }
        #endregion
        public AddStudentViewModel()
        {
            SaveCommand = new RelayCommand(() => SaveCommandExecute(), () => true);


            InitialComboBaseList();
            InitialComboList();
            BaseList();
            
        }

        public ICommand SaveCommand { get; set; }

        public ObservableCollection<StudentEntity> baseList { get; set; } = new ObservableCollection<StudentEntity>();
        public void BaseList()
        {
            baseList.Clear();
            using (var db = new StudentData())
            {
                var info = db.StudentEntities.ToList();
                if (info != null)
                {
                    foreach (var item in info)
                    {
                        baseList.Add(new StudentEntity() {
                            Stu_age = item.Stu_age,
                        Stu_class=item.Stu_class,
                        Stu_gender=item.Stu_gender,
                        Stu_id=item.Stu_id,
                        Stu_name=item.Stu_name
                        });
                    }
                }
            }
        }
        
        public void SaveCommandExecute()
        {
            //判断ID是否重复
            var id = baseList.Where(a => a.Stu_id == Stu_id).ToList();//是否能找到与输入值相同的id
            if (id.Count == 0)//为0则表示没有相同的id
            {
                using (var db = new StudentData())
                {
                    StudentEntity studentEntity = new StudentEntity();

                    studentEntity.Stu_id = Stu_id;
                    studentEntity.Stu_age = Stu_age;
                    studentEntity.Stu_class = Stu_class;
                    studentEntity.Stu_gender = Stu_gender;
                    studentEntity.Stu_name = Stu_name;

                    db.StudentEntities.Add(studentEntity);
                    db.SaveChanges();
                    //学生已经存在和添加成功的提示？？

                    MessageBox.Show("添加成功");

                    BaseList();//添加之后刷新一下数据，否则可以添加相同数据
                }
            }
            else
            {
                MessageBox.Show("该id已经存在");
            }
        }

        public ObservableCollection<ClassEntity> comboList { get; set; } = new ObservableCollection<ClassEntity>();
        public ObservableCollection<ClassEntity> comboBaseList { get; set; } = new ObservableCollection<ClassEntity>();
        public void InitialComboBaseList()
        {
            comboBaseList.Clear();
            using (var db = new StudentData())
            {
                comboBaseList.Clear();
                var info = db.ClassEntities.ToList();
                if (info != null)
                {
                    foreach (var item in info)
                    {
                        comboBaseList.Add(new ClassEntity()
                        {
                            Stu_class = item.Stu_class,
                            Class_id = item.Class_id
                        });
                    }
                }
            }
        }
        public void InitialComboList()
        {
            comboList.Clear();
            using (var db = new StudentData())
            {
                var info = db.ClassEntities.ToList();
                if (info != null)
                {
                    foreach (var item in info)
                    {
                        comboList.Add(new ClassEntity()
                        {
                            Stu_class = item.Stu_class,
                            Class_id = item.Class_id
                        });
                    }
                }
            }
        }

    }
}
