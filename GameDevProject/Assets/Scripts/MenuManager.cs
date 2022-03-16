using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        public void ChangeScene()
        {
            SceneManager.LoadScene("Stage");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
