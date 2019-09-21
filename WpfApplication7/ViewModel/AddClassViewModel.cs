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
    public class AddClassViewModel : ViewModelBase
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                Set(ref text, value);
            }
        }
        public AddClassViewModel()
        {
            AddClass = new RelayCommand(() => AddClassExecute(), () => true);
            BaseList();
        
            }
        public ICommand AddClass { get; set; }


        public ObservableCollection<ClassEntity> baseList { get; set; } = new ObservableCollection<ClassEntity>();
        public void BaseList()
        {
            baseList.Clear();
            using (var db = new StudentData())
            {
                var info = db.ClassEntities.ToList();
                if (info != null)
                {
                    foreach (var item in info)
                    {
                        baseList.Add(new ClassEntity()
                        {
                            Stu_class = item.Stu_class,
                            Class_id = item.Class_id
                        });
                    }
                }
            }
        }


        public  void AddClassExecute()
        {
            ClassEntity classEntity = new ClassEntity();
            var id = baseList.Where(a => a.Stu_class == Text).ToList();//查询班级表中是否存在与输入值相同的班级
            if (id.Count==0)//id为0则表示没有相同的班级
            {
                using (var db = new StudentData())
                {
                    classEntity.Stu_class = Text;

                    db.ClassEntities.Add(classEntity);
                    db.SaveChanges();
                    //添加成功和学号已经存在的提示？？

                    MessageBox.Show("添加成功");
                    BaseList();//添加之后刷新一下数据，否则可以添加相同数据
                }
            }
            else
            {
                MessageBox.Show("该班级已经存在");
            }
        }

    }
}
