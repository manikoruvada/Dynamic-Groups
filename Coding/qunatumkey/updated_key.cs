public class UpdateKey {

	static string qqb;
	static public int zCount;
	static public int oCount;

	public UpdateKey() {
		// getQubit(rta, kta, Sesskey);
	}

	public int getQubit(char rkey, char kta, string sesskey1) {
		string sesskey = sesskey1;
		long l1 = new long(sesskey);
		long l = l1;
		String skb = StrToHex.binaryConvertion(l);
		System.out.println("SessKey Binary: " + skb);
		int countZero = getZeros(skb);
		int countOne = getOnes(skb);
		
		zCount = countZero;
		oCount = countOne;
		
		int qk = genrateQK(rta, kta, countZero, countOne);
		return qk;
	}

	public int genrateQK(char rta, char kta, int countZero, int countOne) {
		int qbt = 0;
		if (rta == '0' && kta == '0') {
			qbt = (int) (0.707 * (countZero + countOne));
			qqb = "00";
		} else if (rta == '1' && kta == '0') {
			qbt = (int) (0.707 * (countZero - countOne));
			qqb = "10";
		} else if (rta == '0' && kta == '1') {
			qbt = countZero;
			qqb = "01";
		} else if (rta == '1' && kta == '1') {
			qbt = countOne;
			qqb = "11";
		}
		return qbt;
	}

	public int getZeros(String sesskey) {
		int countZero = 0;
		for (int i = 0; i < sesskey.length(); i++) {
			char c = sesskey.charAt(i);
			if (c == '0') {
				countZero++;
			}
		}
		System.out.println("000000000: " + countZero);
		return countZero;
	}

	public int getOnes(String sesskey) {

		int countOne = 0;
		for (int i = 0; i < sesskey.length(); i++) {
			char c = sesskey.charAt(i);
			if (c == '1') {
				countOne++;
			}
		}
		System.out.println("11111111111: " + countOne);
		return countOne;
	}

}
