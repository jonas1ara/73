class MedianFinder {
    priority_queue<int> sm;
    priority_queue<int, vector<int>, greater<>> gt;
public:
    MedianFinder() {}
    void addNum(int num) {
        if (gt.size() && num > gt.top()) {
            gt.push(num);
            if (gt.size() > sm.size()) {
                sm.push(gt.top());
                gt.pop();
            }
        } else {
            sm.push(num);
            if (sm.size() > gt.size() + 1) {
                gt.push(sm.top());
                sm.pop();
            }
        }
    }
    double findMedian() {
        return sm.size() > gt.size() ? sm.top() : ((double)sm.top() + gt.top()) / 2;
    }
};