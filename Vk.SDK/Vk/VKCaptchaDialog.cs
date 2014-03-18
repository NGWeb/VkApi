//public class VKCaptchaDialog {
//    private readonly VKError mCaptchaError;
//    private EditText mCaptchaAnswer;
//    private ImageView mCaptchaImage;
//    private ProgressBar mProgressBar;
//    private float mDensity;

//    public VKCaptchaDialog(VKError captchaError) {
//        mCaptchaError = captchaError;
//    }

//    /**
//     * Prepare, create and show dialog for displaying captcha
//     */
//    public void show() {
//        Context context = VKUIHelper.getTopActivity();
//        View innerView = LayoutInflater.from(context).inflate(R.layout.dialog_vkcaptcha, null);
//        assert innerView != null;
//        mCaptchaAnswer = (EditText) innerView.findViewById(R.id.captchaAnswer);
//        mCaptchaImage  = (ImageView) innerView.findViewById(R.id.imageView);
//        mProgressBar   = (ProgressBar) innerView.findViewById(R.id.progressBar);

//        mDensity = context.getResources().getDisplayMetrics().density;
//        readonly AlertDialog dialog = new AlertDialog.Builder(context).setView(innerView).create();
//        mCaptchaAnswer.setOnFocusChangeListener(new View.OnFocusChangeListener() {
//            @Override
//            public void onFocusChange(View v, bool hasFocus) {
//                if (hasFocus) {
//                    dialog.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE);
//                }
//            }
//        });
//        mCaptchaAnswer.setOnEditorActionListener(new TextView.OnEditorActionListener() {
//            @Override
//            public bool onEditorAction(TextView textView, int actionId, KeyEvent keyEvent) {
//                if (actionId == EditorInfo.IME_ACTION_SEND) {
//                    sendAnswer();
//                    return true;
//                }
//                return false;
//            }
//        });

//        dialog.setButton(AlertDialog.BUTTON_NEGATIVE, context.getstring(android.R.string.ok),
//                new DialogInterface.OnClickListener() {
//                    public void onClick(DialogInterface dialog, int which) {
//                        sendAnswer();
//                    }
//                });
//        dialog.setOnCancelListener(new DialogInterface.OnCancelListener() {
//            @Override
//            public void onCancel(DialogInterface dialogInterface) {
//                mCaptchaError.request.cancel();
//            }
//        });
//        loadImage();
//        dialog.show();
//    }
//    private void sendAnswer() {
//        mCaptchaError.answerCaptcha(mCaptchaAnswer.getText() != null ? mCaptchaAnswer.getText().tostring() : "");
//    }
//    private void loadImage() {
//        VKHttpOperation imageOperation = new VKHttpOperation(new HttpGet(mCaptchaError.captchaImg));
//        imageOperation.setHttpOperationListener(new VKHTTPOperationCompleteListener() {
//            @Override
//            public void onComplete(VKHttpOperation operation, byte[] response) {
//                Bitmap captchaImage = BitmapFactory.decodeByteArray(response, 0, response.length);
//                captchaImage = Bitmap.createScaledBitmap(captchaImage, (int) (captchaImage.getWidth() * mDensity), (int) (captchaImage.getHeight() * mDensity), true);
//                mCaptchaImage.setImageBitmap(captchaImage);
//                mCaptchaImage.setVisibility(View.VISIBLE);
//                mProgressBar.setVisibility(View.GONE);
//            }

//            @Override
//            public void onError(VKHttpOperation operation,VKError error) {
//                loadImage();
//            }
//        });
//        RequestFactory.enqueueOperation(imageOperation);
//    }
//}
