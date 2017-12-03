using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemInstanceFactory {

	public ProblemInstanceFactory () {}
	

	public ProblemInstance GetDemoProblemInstance() {
		string s = "LONDON THE THIRD NINE AM BE PREPARED";
		string[] enigm_texts = new string[]{
			"Bernard a 4 ans et sa soeur a la moitié de son âge.\nQuelle âge a la soeur de Bernard si Bernard a 40 ans ?", 
			"Combien d'allumettes faut-il pour faire 4 triangles équilatéraux de côté une allumette ?", 
			"Il y a plusieurs livres sur une étagère.\nSi un livre est le cinquième en partant de la gauche et le cinquième en partant de la droite, combien y a t-il de livres sur cette étagère ?", 
			"Sur le chemin pour aller au supermarché, vous comptez 20 maisons sur votre droite et au retour, vous en dénombrez 20 sur votre gauche. Combien y a-t-il de maisons en tout ?" };
		int[] rotor_values = { 38, 6, 9, 20 };
		string[] enigm_answers = new string[]{ "38", "6", "9", "20" };
		return new ProblemInstance (s, rotor_values, enigm_texts, enigm_answers);
	}
}
