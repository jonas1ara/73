# [271. Encode and Decode Strings (Medium)](https://leetcode.com/problems/encode-and-decode-strings/)

<p>
Design an algorithm to encode <b>a list of strings</b> to <b>a string</b>. The encoded string is then sent over the network and is decoded back to the original list of strings.</p>

<p>
Machine 1 (sender) has the function:
</p><pre>string encode(vector&lt;string&gt; strs) {
  // ... your code
  return encoded_string;
}</pre>

Machine 2 (receiver) has the function:
<pre>vector&lt;string&gt; decode(string s) {
  //... your code
  return strs;
}</pre>
<p></p>

<p>
So Machine 1 does:
</p><pre>string encoded_string = encode(strs);</pre>
<p></p>

<p>
and Machine 2 does:
</p><pre>vector&lt;string&gt; strs2 = decode(encoded_string);</pre>
<p></p>

<p>
<code>strs2</code> in Machine 2 should be the same as <code>strs</code> in Machine 1.
</p>

<p>Implement the <code>encode</code> and <code>decode</code> methods.
</p>

<h2> Example </h2>

<p><b>Example 1:</b></p>

<pre><b>Input:</b> <code>["lint","code","love","you"]</code>
<b>Output:</b> <code>["lint","code","love","you"]</code>
<b>Explanation:</b>
One possible encode method is: "lint:;code:;love:;you"
</pre>

<p><b>Example 2:</b></p>

<pre><b>Input:</b> <code>["we", "say", ":", "yes"]</code>
<b>Output:</b> <code>["we", "say", ":", "yes"]</code>
<b>Explanation:</b>
One possible encode method is: "we:;say:;:::;yes" 
</pre>

<p><b>Note:</b><br>
</p><ul>
<li>The string may contain any possible characters out of 256 valid ascii characters. Your algorithm should be generalized enough to work on any possible characters.</li>
<li>Do not use class member/global/static variables to store states. Your encode and decode algorithms should be stateless.</li>
<li>Do not rely on any library method such as <code>eval</code> or serialize methods. You should implement your own encode/decode algorithm.</li>
</ul><p></p>

**Companies**:  
[Google](https://leetcode.com/company/google), [Square](https://leetcode.com/company/square), [Twitter](https://leetcode.com/company/twitter)

**Related Topics**:  
[String](https://leetcode.com/tag/string/)

**Similar Questions**:
* [Count and Say (Easy)](https://leetcode.com/problems/count-and-say/)
* [Serialize and Deserialize Binary Tree (Hard)](https://leetcode.com/problems/serialize-and-deserialize-binary-tree/)
* [String Compression (Easy)](https://leetcode.com/problems/string-compression/)
* [Count Binary Substrings (Easy)](https://leetcode.com/problems/count-binary-substrings/)
