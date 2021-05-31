using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class StatsMenu : MonoBehaviour
{

    public Text callUni;
    public Text callBern;
    public Text callBino;
    public Text callGeom;
    public Text callPoiss;
    public Text meanUni;
    public Text meanBern;
    public Text meanBino;
    public Text meanGeom;
    public Text meanPoiss;
    public Text meanMeanUni;
    public Text meanMeanBern;
    public Text meanMeanBino;
    public Text meanMeanGeom;
    public Text meanMeanPoiss;
    public Text deviationUni;
    public Text deviationBern;
    public Text deviationBino;
    public Text deviationGeom;
    public Text deviationPoiss;



    public static StatsMenu instance ;

    private void Awake()
    {
        if(instance != null){
          Debug.LogWarning("Il y a plus d'un StatsMenu");
          return ;
        }
        instance = this;
    }



    public void OnEnable()
    {
      int nbIterU = RandomManager.instance.uniform.Count;
      int nbIterBe = RandomManager.instance.bernoulli.Count;
      int nbIterBi = RandomManager.instance.binomial.Count;
      int nbIterG = RandomManager.instance.geometric.Count;
      int nbIterP = RandomManager.instance.poisson.Count;

      callUni.text = nbIterU.ToString();
      callBern.text = nbIterBe.ToString();
      callBino.text = nbIterBi.ToString();
      callGeom.text = nbIterG.ToString();
      callPoiss.text = nbIterP.ToString();


      if(nbIterU != 0){
        float meanU = RandomManager.instance.Mean(RandomManager.instance.uniform);
        meanUni.text = meanU.ToString("F2");
        meanMeanUni.text = RandomManager.instance.MeanDeviationsMean(RandomManager.instance.uniform, meanU).ToString("F2");
        deviationUni.text = RandomManager.instance.StandardDeviation(RandomManager.instance.uniform, meanU).ToString("F2");
      }

      if(nbIterBe != 0){
        float meanBe = RandomManager.instance.Mean(RandomManager.instance.bernoulli);
        meanBern.text = meanBe.ToString("F2");
        meanMeanBern.text = RandomManager.instance.MeanDeviationsMean(RandomManager.instance.bernoulli, meanBe).ToString("F2");
        deviationBern.text = RandomManager.instance.StandardDeviation(RandomManager.instance.bernoulli, meanBe).ToString("F2");
      }

      if(nbIterBi != 0){
        float meanBi = RandomManager.instance.Mean(RandomManager.instance.binomial);
        meanBino.text = meanBi.ToString("F2");
        meanMeanBino.text = RandomManager.instance.MeanDeviationsMean(RandomManager.instance.binomial, meanBi).ToString("F2");
        deviationBino.text = RandomManager.instance.StandardDeviation(RandomManager.instance.binomial, meanBi).ToString("F2");
      }

      if(nbIterG != 0){
        float meanG = RandomManager.instance.Mean(RandomManager.instance.geometric);
        meanGeom.text = meanG.ToString("F2");
        meanMeanGeom.text = RandomManager.instance.MeanDeviationsMean(RandomManager.instance.geometric, meanG).ToString("F2");
        deviationGeom.text = RandomManager.instance.StandardDeviation(RandomManager.instance.geometric, meanG).ToString("F2");
      }

      if(nbIterP != 0){
        float meanP = RandomManager.instance.Mean(RandomManager.instance.poisson);
        meanPoiss.text = meanP.ToString("F2");
        meanMeanPoiss.text = RandomManager.instance.MeanDeviationsMean(RandomManager.instance.poisson, meanP).ToString("F2");
        deviationPoiss.text = RandomManager.instance.StandardDeviation(RandomManager.instance.poisson, meanP).ToString("F2");
      }


    }

}
