using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemInstanceFactory {

	public ProblemInstanceFactory () {}
	




	public ProblemInstance GetDemoProblemInstance() {
		int[] rotor_values = { 3, 5, 1, 9 };
		string s = "LONDON THE THIRD NINE AM BE PREPARED";
		return new ProblemInstance (s, rotor_values);
	}
}
