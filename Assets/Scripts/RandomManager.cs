using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomManager : MonoBehaviour
{
    public static RandomManager instance { get; private set; }
    // public Slider difficulty;
    public bool lifeMustPop = false;
    public float difficulty = 0;
    public float nbWiltCases;


    public List<int> uniform = new List<int>(); //En faire une variable discreète ?
    public List<int> bernoulli = new List<int>();
    public List<int> binomial = new List<int>();
    public List<int> geometric = new List<int>();
    public List<int> poisson = new List<int>();

    private void Awake()
    {
        if(instance != null){
          Debug.LogWarning("Il y a plus d'un RandomManager");
          return ;
        }
        instance = this;
    }

    public bool RandomTrueOrFalse(float p){
        return (Bernoulli(p) == 1);
    }

    public int Uniform(int min, int max){
        var rand = new System.Random();
        int u = rand.Next(min, max + 1);
        uniform.Add(u);
        return u;
    }

    public int Bernoulli(float p){
        float u = Random.Range(0.0f,1.0f);
        int result = 0; // P( X = 0 ) = 1 - p
        if (u <= p) result = 1; // P( X = 1 ) = p
        bernoulli.Add(result);
        return result;
    }

    public int Binomial(int n, float p){
        int result = 0;
        for(int i=0; i<n; i++){
            result += Bernoulli(p);
        }
        binomial.Add(result);

        return result;
    }

    public int Poisson(float lambda){
        int n = 10000;
        int result = Binomial(n, lambda/n);
        poisson.Add(result);
        return result;
    }

    public int Geometric(float p){
        int count = 0;
        while(Bernoulli(p) != 1) count ++;
        geometric.Add(count);
        return count;
    }

    public float Mean<T>(List<T> list){ //MOYENNE
        int count = 0;
        int length = list.Count;
        for(int i = 0; i < length; i++){
            count++;
        }
        if(length > 0) return (float)count/length;
        return -1.0f;
    }

    //Liste des écarts moyens par rapport à la moyenne
    public List<float> MeanDeviations(List<int> list, float mean){ //ÉCARTS À LA MOYENNE
        List<float> result = new List<float>();
        foreach(int element in list){
            result.Add(System.Math.Abs((float)element - mean));
        }
        return result;
    }

    public float MeanDeviationsMean(List<int> list, float mean){
        return Mean(MeanDeviations(list, mean));
    }

    public float QuadraticMean<T>(List<T> list, float mean){
        int sum = 0;
        foreach(T element in list){
            int value = System.Convert.ToInt32(element);
            sum += value * value;
        }
        if(list.Count > 0) return (float)System.Math.Sqrt(sum / list.Count);
        return -1.0f;
    }

    public float StandardDeviation(List<int> list, float mean){ //ÉCART-TYPE
        return QuadraticMean(MeanDeviations(list, mean), mean);
    }
    //L'écart type dans une population est la moyenne quadratique des distances à la moyenne.

}
