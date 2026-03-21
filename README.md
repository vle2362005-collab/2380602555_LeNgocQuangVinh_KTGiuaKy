<!DOCTYPE html>
<html lang="en">
<head>
    <title>Thực hành An toàn thông tin nâng cao</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <div class="container">
        <img src="https://file1.hutech.edu.vn/file/editor/homepage/stories/hinh34/logo%20CMYK-01.png" alt="hutech" style="display: block; margin-left: auto; margin-right: auto; width: 30%;">
        <h4 style="font-weight: bold; text-align: center;">BÀI THỰC HÀNH BẢO MẬT THÔNG TIN NÂNG CAO</h4>
        <ul style="margin-top: 30px;">
            <li><a href="/caesar">Ceasar Cipher</a></li>
            <li><a href="/rsa">RSA Cipher</a></li>
        </ul>
    </div>
</body>
</html>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Caesar Cipher</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <div class="container">
        <table class="table">
            <tr><td style="text-align: center; font-weight: bold; font-size: 25px;">CAESAR CIPHER</td></tr>
            <tr><td style="font-weight: bold; color: blue">ENCRYPTION</td></tr>
            <tr>
                <td>
                    <form method="POST" action="/encrypt">
                        <div class="mb-3">
                            <label class="form-label">Plain text:</label>
                            <input type="text" class="form-control" name="inputPlainText" placeholder="Input Plain Text" required autofocus/>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Key:</label>
                            <input type="number" class="form-control" name="inputKeyPlain" placeholder="Input Key" required/>
                        </div>
                        <button type="submit" class="btn btn-primary">Encrypt</button>
                    </form>
                </td>
            </tr>
            <tr><td style="font-weight: bold; color: blue">DECRYPTION</td></tr>
            <tr>
                <td>
                    <form method="POST" action="/decrypt">
                        <div class="mb-3">
                            <label class="form-label">Cipher text:</label>
                            <input type="text" class="form-control" name="inputCipherText" placeholder="Input Cipher Text" required/>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Key:</label>
                            <input type="number" class="form-control" name="inputKeyCipher" placeholder="Input Key" required/>
                        </div>
                        <button type="submit" class="btn btn-success">Decrypt</button>
                    </form>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
