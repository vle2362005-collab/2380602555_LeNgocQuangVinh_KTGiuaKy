<button type="submit" class="btn btn-primary">Encrypt</button>
                        
                        {% if encrypted_text %}
                        <div class="alert alert-success mt-3" style="font-weight: bold;">
                            Encrypted text: <span style="color: red;">{{ encrypted_text }}</span>
                        </div>
                        {% endif %}
                    </form>
                </td>
                <button type="submit" class="btn btn-success">Decrypt</button>
                        
                        {% if decrypted_text %}
                        <div class="alert alert-info mt-3" style="font-weight: bold;">
                            Decrypted text: <span style="color: red;">{{ decrypted_text }}</span>
                        </div>
                        {% endif %}
                    </form>
                </td>
