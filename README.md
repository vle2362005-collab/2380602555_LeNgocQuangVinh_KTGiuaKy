# ... (giữ nguyên phần đầu) ...

@app.route("/encrypt", methods=['POST'])
def caesar_encrypt():
    text = request.form['inputPlainText']
    key = int(request.form['inputKeyPlain'])
    Caesar = CaesarCipher()
    encrypted_text = Caesar.encrypt_text(text, key)
    
    # Thay đổi ở đây: Trả về lại trang caesar.html và truyền theo biến encrypted_text
    return render_template('caesar.html', encrypted_text=encrypted_text)

@app.route("/decrypt", methods=['POST'])
def caesar_decrypt():
    text = request.form['inputCipherText']
    key = int(request.form['inputKeyCipher'])
    Caesar = CaesarCipher()
    decrypted_text = Caesar.decrypt_text(text, key)
    
    # Thay đổi ở đây: Trả về lại trang caesar.html và truyền theo biến decrypted_text
    return render_template('caesar.html', decrypted_text=decrypted_text)

# ... (giữ nguyên phần cuối) ...
